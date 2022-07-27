using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_with_file.FileStreamStreamReader
{
    /// <summary>
    /// Classe para testar o uso da classe FileStream e StreamReader, para aprendizado
    /// </summary>
    public class FileStreamStreamReaderDemo : FileDemo
    {
        public override void GetFileText(string sourcePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(sourcePath, FileMode.Open); // File.OpenRead(path);
                sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

            //necessário fechar caso não use o using bloco 
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
