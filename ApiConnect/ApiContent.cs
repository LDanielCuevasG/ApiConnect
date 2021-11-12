using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnect
{
    class ApiContent
    {

        public static HttpContent GetJsonContent(object data)
        {
            StringContent content = null;

            string jsonString = JsonConvert.SerializeObject(data);
            content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return content;
        }

        public static MultipartFormDataContent GetFormContent(object data)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            GetFormContent(form, String.Empty, data);
            return form;
        }

        private static MultipartFormDataContent GetFormContent(MultipartFormDataContent form, string baseName, object data)
        {
            if (String.IsNullOrWhiteSpace(baseName) == false) {
                baseName = $"{baseName}.";
            }

            if (data != null)
            {
                Type type = data.GetType();
                IList<PropertyInfo> properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Type propertyType = property.PropertyType;
                    string propertyName = property.Name;
                    object propertyValue = property.GetValue(data);

                    if (propertyValue != null)
                    {
                        string name = $"{baseName}{propertyName}";

                        if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime)) {
                            form.Add(new StringContent(propertyValue.ToString()), name);
                        }
                        else if (propertyType == typeof(IFormFile))
                        {
                            IFormFile file = (IFormFile)propertyValue;
                            MemoryStream memoryStream = new MemoryStream();
                            file.CopyTo(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();
                            form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), name, file.FileName);
                        }
                        else if (propertyType.IsGenericType && (propertyType.GetGenericTypeDefinition() == typeof(List<>)))
                        {
                            IList items = (IList)propertyValue;
                            for (int i = 0; i < items.Count; ++i)
                            {
                                object item = items[i];
                                GetFormContent(form, $"{name}[{i}]", item);
                            }
                        }
                        else {
                            GetFormContent(form, $"{name}", propertyValue);
                        }
                    }
                }

            }

            return form;
        }

    }
}
