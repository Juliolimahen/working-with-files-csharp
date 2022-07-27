using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace working_with_file
{
    public class Demo1
    {
        public string? SourcePath { get; set; }
        public string? TargetPath { get; set; }

        public virtual void GetFileText(string sourcePath)
        {
            try
            {
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
        public virtual void FileTextCopy(string sourcePath, string targetPath)
        {
            try
            {
                File.Copy(sourcePath, targetPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
