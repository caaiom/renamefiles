using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RenameFiles
{
    public class Manager
    {

        private string BuildFilePathName(string path, string name)
        {
            return Path.Combine(@path, name);
        }

        private bool FoundFile(List<System.IO.FileInfo> files, string part)
        {
            return files.Where(func => func.Name.Contains(part)).Count() > 0;
        }

        private static void CloseProgram()
        {
            Environment.Exit(0);
        }

        public static bool ReadInput(string input, RenameFile.InputStep? inputStep = null)
        {
            if (input == "quit")
                CloseProgram();
            else if (String.IsNullOrEmpty(input))
                return false;

            if (inputStep == RenameFile.InputStep.Path)
            {
                if (Directory.Exists(@input)) return true;
                return false;
            }


            return true;
        }

        private List<FileInfo> GetFilesInFolder(string path)
        {
            return new DirectoryInfo(@path).GetFiles().ToList();
        }

        public int RenameIt(RenameFile objFile)
        {
            List<FileInfo> files = GetFilesInFolder(@objFile.FilePath);
            int fileAffect = 0;

            if (FoundFile(files, objFile.FilePart))
            {
                foreach (var file in files)
                {
                    if (file.Name.Contains(objFile.FilePart))
                    {
                        System.IO.File.Move(BuildFilePathName(objFile.FilePath, file.Name), BuildFilePathName(objFile.FilePath, file.Name.Replace(objFile.FilePart, objFile.FileNewPart)));
                        fileAffect++;
                    }
                }
            }
            else
                throw new FileNotFoundException();

            return fileAffect;
        }

    }
}
