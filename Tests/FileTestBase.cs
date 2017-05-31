using System;
using System.IO;

namespace Tests
{
    public class FileTestBase
    {
        protected static void DeleteFileIfExists(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected static void CreateFileIfNotExists(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    var a = File.Create(path);
                    a.Close();
                }
            }
            catch (Exception e)
            {

            }
        }
        
        protected static string BuildFilePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                           AppDomain.CurrentDomain.RelativeSearchPath ?? "") + path;
        }

        protected static string GetFileContent(string path)
        {
            try
            {
                return File.ReadAllText(BuildFilePath(path)).Replace("\r\n", string.Empty);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
