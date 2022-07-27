using System.IO;
using working_with_file;
using working_with_file.FileAndFileInfo;
using working_with_file.FileStreamStreamReader;
using working_with_file.FileStreamWriter;

class Program
{
    private static string sourcePath = @"C:\ws-projetos\teste.txt";
    private static string targetPath = @"C:\ws-projetos\file2.txt";
    private static FileDemo? d1 = null;
    private static FileInfoDemo? d2 = null;
    private static FileStreamStreamReaderDemo? f1 = null;
    private static FileStreamStreamReaderDemo2? f2 = null;
    private static FileStreamWriter s1 = null;

    static void Main(string[] args)
    {
        d1 = new FileDemo();
        d2 = new FileInfoDemo();
        f1 = new FileStreamStreamReaderDemo();
        f2 = new FileStreamStreamReaderDemo2();
        s1 = new FileStreamWriter();

        Console.WriteLine("\nD1");
        d1.GetFileText(sourcePath);
        d1.FileTextCopy(sourcePath, targetPath);
        Console.WriteLine("\nD2");
        d2.GetFileText(sourcePath);
        d2.FileTextCopy(targetPath, sourcePath);
        Console.WriteLine("\nF1");
        f1.GetFileText(sourcePath);
        Console.WriteLine("\nF2");
        f2.GetFileText(sourcePath);
        Console.WriteLine("\nS1");
        s1.FileTextCopy(sourcePath, targetPath);
        s1.GetFileText(targetPath);
    }
}