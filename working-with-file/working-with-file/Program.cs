using System.IO;
using working_with_file;
using working_with_file.FileAndFileInfo;

class Program
{
    static void Main(string[] args)
    {
        Demo1 d1 = new Demo1();
        Demo2 d2 = new Demo2();
        string sourcePath = @"C:\ws-projetos\teste.txt";
        string targetPath = @"C:\ws-projetos\file2.txt";

        d1.GetFileText(sourcePath);
        d1.FileTextCopy(sourcePath, targetPath);
        d2.GetFileText(sourcePath);
        d2.FileTextCopy(targetPath, sourcePath);
    }
}



