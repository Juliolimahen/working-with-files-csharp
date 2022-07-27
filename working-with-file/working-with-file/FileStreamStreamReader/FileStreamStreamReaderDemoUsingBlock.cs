using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_with_file.FileStreamStreamReader
{
    /// <summary>
    /// Classe para testar o uso da classe FileStream e StreamReader, 
    /// usando using block, para aprendizado
    /// </summary>
    public class FileStreamStreamReaderDemoUsingBlock : FileDemo
    {
        public override void GetFileText(string sourcePath)
        {
            try
            {
                using (FileStream fs = new FileStream(sourcePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
