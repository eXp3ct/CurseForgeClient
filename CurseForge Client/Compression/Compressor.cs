using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Compression
{
    public static class Compressor
    {
        public static string StartCompress(string directoryPath)
        {
            var zipPath = Directory.GetParent(directoryPath) + @"\mods.zip";
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipArchive zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create);

            foreach (string filePath in Directory.GetFiles(directoryPath))
            {
                zipArchive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
            }

            zipArchive.Dispose();
            MessageBox.Show("Mods are successfuly compressed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return zipPath;
        }
        public static void Decompress(string zipPath)
        {
            string modsDirectory = Path.Combine(Directory.GetParent(zipPath).FullName, "mods");
            ZipFile.ExtractToDirectory(zipPath, modsDirectory);
            File.Delete(zipPath);
        }

    }
}
