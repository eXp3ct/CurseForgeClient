namespace CurseForgeClient.Model;

/*public struct ModFile
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int ModId { get; set; }
    public string DisplayName { get; set; }
    public string FileName { get; set; }
    public string DownloadUrl { get; set; }
    public List<string> GameVersions { get; set; }
}
*/
public class ModFiles
{
    public List<ModFile> Data { get; set; }
}
public class ModFile
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int ModId { get; set; }
    public string DisplayName { get; set; }
    public string FileName { get; set; }
    public string DownloadUrl { get; set; }
    public long FileLength { get; set; }
    public DateTime FileDate { get; set; }
    public List<string> GameVersions { get; set; }
}