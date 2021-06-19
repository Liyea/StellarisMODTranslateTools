using System;
using System.Collections.Generic;
using System.IO;

namespace TranslateTools
{
    public class MODDataBase
    {
        public string MODName;
        public string SupportVesrion;
        public string Path;
        public Dictionary<Language, MODFolder> Folders;
        public DateTime MODLastChange;
        public Language OriginLanguage;
        public Language TargetLanguage;

        public MODDataBase()
        {
            MODName = "New MOD";
            SupportVesrion = "*.*.*";
            Path = "";
            Folders = new Dictionary<Language, MODFolder>();
        }

        public MODDataBase(StreamReader versionFile)
        {

        }

        public MODDataBase(string path)
        {
            Folders = new Dictionary<Language, MODFolder>();

            //Find descriptor file
            string descriptorPath = path + "\\descriptor.mod";
            if (!File.Exists(descriptorPath))
                throw new FileLoadException("\"Descriptor.mod\" doesn't exist.");
            Path = path;
            
            // Read MOD Name
            StreamReader reader = new StreamReader(descriptorPath);  
            string line = reader.ReadLine();
            int StartIndex = line.IndexOf('\"');
            int EndIndex = line.LastIndexOf('\"');
            MODName = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

            // Read SupportVesrion
            SupportVesrion = "*.*.*";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] lines = line.Split('=');
                if (lines[0] == "supported_version")
                {
                    SupportVesrion = lines[1].Substring(1, lines[1].Length - 2);
                    break;
                }
            }
            reader.Close();

            // Check MOD Language folder
            for (int i = 0; i < 8; i++)
            {
                Language li = (Language)i;
                string folderPath = Path + "\\localisation\\" + MODLanguage.GetFolderName(li);
                if (Directory.Exists(folderPath))
                {
                    Folders.Add(li, new MODFolder(folderPath, this, false));
                    Folders[li].IsOrigin = true;
                }
            }
            if (Folders.Count == 0)
                throw new FileLoadException("This MOD doesn't have localisation files.");
        }

        public MODFolder[] GetFoldersArray()
        {
            Dictionary<Language, MODFolder>.ValueCollection folderValue = Folders.Values;
            List<MODFolder> folderArray = new List<MODFolder>();
            foreach (var folder in folderValue)
            {
                folderArray.Add(folder);
            }
            return folderArray.ToArray();
        }
        
        public void AddFolder(string folderPath,Language language, bool loadFiles)
        {
            MODFolder folder = new MODFolder(folderPath, this, loadFiles);
            Folders.Add(language, folder);
        }

        public void GenerateVersionFile(string versionFilePath)
        {
            StreamWriter versionFile = new StreamWriter(versionFilePath);
            versionFile.WriteLine(MODName);
            versionFile.WriteLine(SupportVesrion);
            Dictionary<Language, MODFolder>.ValueCollection folderValues = Folders.Values;
            foreach (var folder in folderValues)
            {
                if (!folder.IsOrigin)
                    continue;
                versionFile.WriteLine("<folder>");
                versionFile.WriteLine(folder.Language.ToString());
                versionFile.WriteLine(folder.ModifyTime.ToString());
                Dictionary<string, MODFile>.ValueCollection fileValues = folder.Files.Values;
                foreach (var file in fileValues)
                {
                    versionFile.WriteLine("<file>");
                    versionFile.WriteLine(file.Name);
                    //versionFile.WriteLine("<properties>");
                    Dictionary<string, MODProperty>.ValueCollection propertyValues = file.Properties.Values;
                    foreach (var property in propertyValues)
                    {
                        versionFile.WriteLine(property.GetLine());
                    }
                    //versionFile.WriteLine("<properties_end>");
                    versionFile.WriteLine("<file_end>");
                }
                versionFile.WriteLine("<folder_end>");
            }
            versionFile.Close();
        }
    }
}
