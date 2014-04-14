using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath, filePart, fileNewPart;

            while (true)
            {

                Console.WriteLine("Informe o caminho dos arquivos : ");
                filePath = Console.ReadLine();
                Console.WriteLine("Informe o trecho a ser renomeado : ");
                filePart = Console.ReadLine();
                Console.WriteLine("Informe com o que quer renomear : ");
                fileNewPart = Console.ReadLine();

                Console.WriteLine("Tem certeza que deseja renomear? Y/N");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    Rename(filePath, filePart, fileNewPart);
                }
                else if (input == "quit")
                {
                    break;
                }
                else if (input == "n")
                {
                    Console.Clear();
                }
            }
        }

        public static void Rename(string path, string part, string newpart)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@path);
                FileInfo[] files = dirInfo.GetFiles();
                string oldName, newName;
                int fileAffect = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.Contains(part))
                    {
                        oldName = @path + "\\" + files[i].Name;
                        newName = @path + "\\" + files[i].Name.Replace(part, newpart);

                        File.Move(oldName, newName);

                        fileAffect++;
                    }
                }
                // Mensagem de sucesso 
                Console.WriteLine(fileAffect + " arquivos(s) foram renomeados");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
