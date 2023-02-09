namespace CurseForgeClient.Model;

public struct Mod
{
    public int Id { get; set; }
    public ModLogo Logo { get; set; }
    public Image ModLogo { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }
    public List<ModFile> LatestFiles { get; set; }    

    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name} | Slug: {Slug} | {Logo.Url}";
    }
}
public struct ModData
{
    public Mod Data { get; set; }
}
public struct ModsData
{
    public List<Mod> Data { get; set; }
}
public struct ModLogo
{
    public string Url { get; set; }
}
public struct FileIndex
{
    public string GameVersion { get; set; }
    public int FileId { get; set; }
    public string FileName { get; set; }
    public int ReleaseType { get; set; }
    public int GameVersionTypeId { get; set; }
    public int ModLoader { get; set; }
}
public struct LatestFilesIndex
{
    public List<FileIndex> LatestFilesIndexes { get; set; }
}
public struct ModLinks
{
    public string WebSiteUrl { get; set; }
    public string WikiUrl { get; set; }
}