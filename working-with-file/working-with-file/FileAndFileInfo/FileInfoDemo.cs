using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace working_with_file.FileAndFileInfo
{
    /// <summary>
    /// Classe para testar o uso da classe FileInfo, para aprendizado
    /// </summary>
    public class FileInfoDemo : FileDemo
    {
        public override void GetFileText(string sourcePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
        public override void FileTextCopy(string sourcePath, string targetPath)
        {
            FileInfo fileInfo = new FileInfo(sourcePath);
            try
            {
                fileInfo.CopyTo(targetPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
