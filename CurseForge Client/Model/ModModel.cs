using Newtonsoft.Json;
using System.ComponentModel;

namespace CurseForgeClient.Model;

public class Mod
{
    public int Id { get; set; }
    public ModLogo? Logo { get; set; }
    [JsonIgnore]
    public Image? ModLogo { get; set; } = null;
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name} | Slug: {Slug} | {Logo.Url}";
    }
}
public class ModData
{
    public Mod? Data { get; set; }
}
public class ModsData
{
    public List<Mod>? Data { get; set; }
}
public class ModLogo
{
    public string? Url { get; set; }
}