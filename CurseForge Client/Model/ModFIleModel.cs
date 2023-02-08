namespace CurseForgeClient.Model;


public struct ModFiles
{
    public List<ModFile> LatestFiles { get; set; }
}

public struct ModFile
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int ModId { get; set; }
    public string DisplayName { get; set; }
    public string FileName { get; set; }
    public string DownloadUrl { get; set; }
    public List<string> GameVersions { get; set; }
}