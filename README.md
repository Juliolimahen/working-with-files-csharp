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

### Using block
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement

- Sintaxe simplificada que garante que os objetos IDisposable serão fechados.
- Objetos IDisposable NÃO são gerenciados pelo CLR. Eles precisam ser
manualmente fechados.

- Exemplos: Font, FileStream, StreamReader, StreamWriter

Demo 1
````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\file1.txt";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
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
````
Demo 2
````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\file1.txt";
            try
            {
                using (StreamReader sr = File.OpenText(path))
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
````

### StreamWriter
https://msdn.microsoft.com/en-us/library/system.io.streamwriter(v=vs.110).aspx
- É uma stream capaz de escrever caracteres a partir de uma stream binária (ex: FileStream).
- Suporte a dados no formato de texto.
Instantiation:
    - Several constructors
    - File / FileInfo
    - CreateText(path)
    - AppendText(String)

Demo

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
                string[] lines = File.ReadAllLines(sourcePath);
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
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
````

### Directory, DirectoryInfo

Directory, DirectoryInfo
- Namespace System.IO
- Operações com pastas (create, enumerate, get files, etc.).
- Directory
- static members (simple, but performs security check for each operation)
- https://msdn.microsoft.com/en-us/library/system.io.directory(v=vs.110).aspx
- DirectoryInfo
- instance members
- https://msdn.microsoft.com/en-us/library/system.io.directoryinfo(v=vs.110).aspx18/08/2018


Demo
- listar as pastas a partir de uma pasta informada
- listar os arquivos a partir de uma pasta informada
- criar uma pasta

````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\myfolder";
            try
            {
                var folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS:");
                foreach (string s in folders)
                {
                    Console.WriteLine(s);
                }
                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES:");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                Directory.CreateDirectory(@"c:\temp\myfolder\newfolder");
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

### Path
- Namespace System.IO
- Realiza operações com strings que contém informações de arquivos ou pastas.
- https://msdn.microsoft.com/en-us/library/system.io.path(v=vs.110).aspx

Demo
````cs
using System;
using System.IO;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\myfolder\file1.txt";
            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
            Console.WriteLine("PathSeparator: " + Path.PathSeparator);
            Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
            Console.WriteLine("GetFileName: " + Path.GetFileName(path));
            Console.WriteLine("GetExtension: " + Path.GetExtension(path));
            Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
            Console.WriteLine("GetTempPath: " + Path.GetTempPath());
        }
    }
}
````