using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TranslateTools
{
    public class MODDataBase
    {
        public string MODName;
        public string SupportVesrion;
        public string MODPath;
        public Dictionary<Language, MODFolder> Folders;
        public Dictionary<Language, MODFolder> VersionFolders;
        public Dictionary<string, MODProperty> Properties;
        public Dictionary<string, MODProperty> VersionProperties;
        public DateTime MODLastChange;
        public Language OriginLanguage;
        public Language TargetLanguage;

        public MODDataBase()
        {
            MODName = "New MOD";
            SupportVesrion = "*.*.*";
            MODPath = "";
            Folders = new Dictionary<Language, MODFolder>();
        }

        public MODDataBase(string MODPath,string MODName)
        {
            // TODO: MOD generator
            Folders = new Dictionary<Language, MODFolder>();
            StreamWriter Descriptor = new StreamWriter(MODPath+"\\descriptor.mod");
            Descriptor.WriteLine();
        }

        public MODDataBase(string descriptorPath)
        {
            Folders = new Dictionary<Language, MODFolder>();

            //Find descriptor file            
            if (!File.Exists(descriptorPath))
                throw new FileLoadException("MODDataBase error", new DescriptorMissingException());
            MODPath = Path.GetDirectoryName(descriptorPath);
            
            // Read MOD Name
            StreamReader reader = new StreamReader(descriptorPath);  
            string line = reader.ReadLine();
            int StartIndex = line.IndexOf('\"');
            int EndIndex = line.LastIndexOf('\"');
            MODName = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

            // Read SupportVesrion
            SupportVesrion = "*.*.*";
            bool hasSupportedVersion = false;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] lines = line.Split('=');
                if (lines[0] == "supported_version")
                {
                    SupportVesrion = lines[1].Substring(1, lines[1].Length - 2);
                    hasSupportedVersion = true;
                    break;
                }
            }
            reader.Close();

            if (!hasSupportedVersion)
                throw new FileLoadException("MODDataBase error", new DescriptorInvalidException());

            // Check MOD Language folder
            for (int i = 0; i < 8; i++)
            {
                Language li = (Language)i;
                string folderPath = MODPath + "\\localisation\\" + MODLanguage.GetFolderName(li);
                if (Directory.Exists(folderPath))
                {
                    Folders.Add(li, new MODFolder(folderPath, this, false));
                    Folders[li].IsOrigin = true;
                }
            }
            if (Folders.Count == 0)
                throw new FileLoadException("MODDataBase error", new DescriptorWithoutFoldersException());
        }

        public MODFolder[] GetFolders()
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
            //versionFile.WriteLine(SupportVesrion);
            Dictionary<Language, MODFolder>.ValueCollection folderValues = Folders.Values;
            foreach (var folder in folderValues)
            {
                if (!folder.IsOrigin)
                    continue;
                versionFile.WriteLine($"<folder>");
                versionFile.WriteLine(folder.Language.ToString());
                versionFile.WriteLine(folder.ModifyTime.ToString());
                Dictionary<string, MODFile>.ValueCollection fileValues = folder.Files.Values;
                foreach (var file in fileValues)
                {
                    versionFile.WriteLine($"<file>");
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

        public bool LoadVersionFile(string filePath)
        {
            VersionFolders = new Dictionary<Language, MODFolder>();
            VersionProperties = new Dictionary<string, MODProperty>();

            StreamReader versionFile = new StreamReader(filePath);
            string line = versionFile.ReadLine();
            MODFolder folder;
            MODFile file;

            if (line != MODName)
                return false;

            while (!versionFile.EndOfStream)
            {
                line = versionFile.ReadLine();
                if (line == "<folder>")
                {
                    line = versionFile.ReadLine();
                    Language l = (Language)Enum.Parse(typeof(Language), line, true);
                    folder = new MODFolder(l, this);
                    VersionFolders.Add(l, folder);
                    while (!versionFile.EndOfStream)
                    {
                        line = versionFile.ReadLine();
                        if (line == "<folder_end>")
                            break;
                        else if (line == "<file>")
                        {
                            line = versionFile.ReadLine();
                            
                            file = new MODFile(line);
                            folder.AddFile(file);

                            while (!versionFile.EndOfStream)
                            {
                                line = versionFile.ReadLine();
                                if (line == "<file_end>")
                                    break; 
                                MODProperty property = new MODProperty(line, file);
                                folder.Properties.Add(property.Name, property);
                                
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
