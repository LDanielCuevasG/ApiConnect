# ApiConnect
Implementation to connect client with an API
<br /> <br />
Methods:
  - Call

### Considerations
- Sent data can be a json/formdata object 
- Received data must be a json object

## Usage

Data  received from API
| character_id | name | genre | serie | 
| ------ | ------ | ------ | ------ |
| 1 | Maki Nishikino | F | Love Live! | 
| 2 | Mash Kyrielight | F | Fate Grand Order | 
| 3 | Shinobu Oshino | F | Monogatari Series |

<br />

### Character class

```csharp
public class Character
{
    public string CharacterId { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Serie { get; set; }
}
```
<br />

### Call(method)

```csharp
public Character GetCharacter(string id)
{
    Character character = null;

    ApiConnect<Character> api = new ApiConnect<Character>(url);
    api.Method = $"api/v1/Character/{id}";
    character = api.Call();

    return character;
}
```

```csharp
public List<Character> GetCharacters()
{
    List<Character> characters = null;

    ApiConnect<List<Character>> api = new ApiConnect<List<Character>>(url);
    api.Method = $"api/v1/Character";
    characters = api.Call();

    return characters;
}
```
