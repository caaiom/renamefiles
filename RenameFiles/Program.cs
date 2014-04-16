
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
            string input = "";
            string output = "";
            Manager objManager = new Manager();

            while (true)
            {
                RenameFile objFile = new RenameFile();

                while (!Manager.ReadInput(input, RenameFile.InputStep.Path))
                {
                    Console.WriteLine("Informe o caminho dos arquivos: ");
                    input = Console.ReadLine();
                }

                objFile.FilePath = input;

                do
                {
                    Console.WriteLine("Informe o trecho a ser renomeado : ");
                    input = Console.ReadLine();
                } while (!Manager.ReadInput(input, RenameFile.InputStep.Part));

                objFile.FilePart = input;

                do
                {
                    Console.WriteLine("Informe com o que quer renomear : ");
                    input = Console.ReadLine();
                } while (!Manager.ReadInput(input, RenameFile.InputStep.NewPart));

                objFile.FileNewPart = input;

                do
                {
                    Console.WriteLine("Tem certeza que deseja renomear? Y/N");
                    input = Console.ReadLine().ToLower();
                } while (!Manager.ReadInput(input));

                try
                {
                    switch (input)
                    {
                        case "y":
                            int filesAffect = objManager.RenameIt(objFile);
                            if (filesAffect > 0)
                                output = filesAffect + " arquivos(s) foram renomeados";
                            else
                                output = "Nenhuma arquivo foi renomeado";
                            break;
                        case "quit":
                            Environment.Exit(0);
                            break;
                        case "n":
                            Console.Clear();
                            break;
                        default:
                            output = "O comando especificado não existe.";
                            break;
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    output = "O diretório especificado não foi encontrado.";
                }
                catch (FileNotFoundException)
                {
                    output = "Não há arquivos com o trecho ou nome especificado.";
                }
                catch (Exception ex)
                {
                    output = "Ocorreu um erro ao tentar renomear os arquivos. Erro: " + ex.Message;
                }

                Console.WriteLine(output);
            }
        }
    }
}
