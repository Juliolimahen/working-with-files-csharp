# working-with-files-csharp

## File, FileInfo
- Namespace System.IO
- Realiza operações com arquivos (create, copy, delete, move, open, etc.) e
ajuda na criação de objetos FileStream.

- File
    - static members (simples, mas realiza verificação de segurança para cada operação)
    - https://msdn.microsoft.com/en-us/library/system.io.file(v=vs.110).aspx

- FileInfo
    - instance members
    - https://msdn.microsoft.com/en-us/library/system.io.fileinfo(v=vs.110).aspx

## Quando usar File ou FileInfo
- Programa simples usar File, pois só será realizada poucas ações e não tera o problema de perda de desenpenho
- Programa mais completo, com varias operações 

## IOException

- Classe resposável por todas as exceções possíveis que podem ocorrer quando se trabalha com um arquivos  
Namespace System.IO
- Nomes auto explicativos 
    - IOException
    - DirectoryNotFoundException
    - DriveNotFoundException
    - EndOfStreamException
    - FileLoadException
    - FileNotFoundException
    - PathTooLongException
    - PipeException

Demo File
````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";
            try
            {
                File.Copy(sourcePath, targetPath);
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
    }
}
````

Demo FileInfo

````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";
            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
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
    }
}
````

## FileStream, StreamReader

### FileStream
Disponibiliza uma stream associada a um arquivo, permitindo operações de leitura
e escrita.
- Suporte a dados binários.

Instanciação
- Vários construtores
- File / File Info

### StreamReader

https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.90).aspx

É uma stream capaz de ler caracteres a partir de uma stream binária (ex:
FileStream).
- Suporte a dados no formato de texto.

Instanciação:
- Vários construtores
- File / FileInfo

