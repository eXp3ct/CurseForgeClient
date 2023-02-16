using Microsoft.AspNetCore.Mvc;

namespace Server.API
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public string FilePath => Program.FilePath;
        [HttpGet("mods")]
        public async Task<FileStreamResult> DownloadFile()
        {
            var filePath = FilePath;
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(stream, "application/octet-stream", Path.GetFileName(filePath));
        }
        [HttpGet("mods/size")]
        public ActionResult<long> GetFileSize()
        {
            var filePath = FilePath;
            var fileSize = new FileInfo(filePath).Length;
            return fileSize;
        }
    }
}
/**/

/**/