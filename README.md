# ApiConnection
Simple implementation to connect with an API
<br /> <br />
Methods:
  - Call

### Considerations
- Sent data can be a json/form object 
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

    ApiConnection<Character> api = new ApiConnection<Character>(url);
    character = api.Call($"api/v1/Character/{id}");

    return character;
}
```

```csharp
public List<Character> GetCharacters()
{
    List<Character> characters = null;

    ApiConnection<List<Character>> api = new ApiConnection<List<Character>>(url);
    characters = api.Call($"api/v1/Character");

    return characters;
}
```
