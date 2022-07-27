using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_with_file.FileStreamStreamReader
{
    /// <summary>
    /// Classe para testar o uso da classe FileStream e StreamReader, 
    /// usando using block, percorrer mai sde uma linha, para aprendizado
    /// </summary>
    public class FileStreamStreamReaderDemo2UsingBlock : FileDemo
    {
        public override void GetFileText(string sourcePath)
        {
            try
            {
                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    while (!sr.EndOfStream)
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
