using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_with_file.FileStreamStreamReader
{
    /// <summary>
    /// Classe para testar o uso da classe FileStream e StreamReader, 
    /// percorrer mai sde uma linha, para aprendizado
    /// </summary>
    public class FileStreamStreamReaderDemo2 : FileDemo
    {
        public override void GetFileText(string sourcePath)
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(sourcePath);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}
