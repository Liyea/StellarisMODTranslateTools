using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TranslateTools
{
    public class ModDataBase
    {
        #region
        /// <summary>
        /// The Name of mod
        /// </summary>
        public string ModName;
        /// <summary>
        /// The support version of mod
        /// </summary>
        public string SupportVesrion;
        /// <summary>
        /// The folder path of mod
        /// </summary>
        public string ModPath;
        /// <summary>
        /// The folders in localisation folder
        /// </summary>
        public Dictionary<Language, ModFolder> Folders;
        /// <summary>
        /// The localisation files
        /// </summary>
        public Dictionary<string, ModFile> Files;
        /// <summary>
        /// The properties of localisation
        /// </summary>
        public Dictionary<string, ModProperty> Properties;
        /// <summary>
        /// The last update time of mod
        /// </summary>
        public DateTime ModLastChange;
        /// <summary>
        /// <see langword="true"/>: This is a translate mod. 
        /// <see langword="false"/>: This is the original mod.
        /// </summary>
        public bool IsTranslateMod { get; }

        // The folder of checking version
        private Dictionary<Language, ModFolder> CheckingFolders;
        // The properties of checking version        
        private Dictionary<string, ModProperty> CheckingProperties;
        private bool checkDataExsist = false;
        #endregion

        /// <summary>
        /// Create an empty database
        /// </summary>
        public ModDataBase()
        {
            ModName = "New Mod";
            SupportVesrion = "*.*.*";
            ModPath = "";
            Folders = new Dictionary<Language, ModFolder>();
            Properties = new Dictionary<string, ModProperty>();
            IsTranslateMod = true;
        }

        /// <summary>
        /// Generate a new Mod with descriptor and folders
        /// </summary>
        /// <param name="modFolderPath">The full path of mod folder</param>
        /// <param name="modName">The name of new mod</param>
        public ModDataBase(string modFolderPath,string modName)
        {
            // TODO: Mod generator
            ModName = modName;
            Folders = new Dictionary<Language, ModFolder>();
            Properties = new Dictionary<string, ModProperty>();
            StreamWriter Descriptor = new StreamWriter(modFolderPath + "\\descriptor.mod");
            Descriptor.WriteLine();
            IsTranslateMod = true;
        }

        /// <summary>
        /// Load the descriptor file and localisation files
        /// </summary>
        /// <param name="descriptorPath">The full path of descriptor file, include file name</param>
        /// <param name="loadFile"><see langword="true"/>: Load files during construct ModDataBase; <see langword="false"/>: Only create folders properties</param>
        /// <param name="isTranslate"><see langword="true"/>: This mod is a tranlate mod; <see langword="false"/>: This mod is the original mod</param>
        /// <exception cref="FileLoadException"></exception>
        public ModDataBase(string descriptorPath, bool loadFile, bool isTranslate)
        {
            Folders = new Dictionary<Language, ModFolder>();
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();

            //Find descriptor file            
            if (!File.Exists(descriptorPath))
                throw new FileLoadException("ModDataBase error", new DescriptorMissingException());
            ModPath = Path.GetDirectoryName(descriptorPath);
            
            // Read Mod Name
            StreamReader reader = new StreamReader(descriptorPath);  
            string line = reader.ReadLine();
            int StartIndex = line.IndexOf('\"');
            int EndIndex = line.LastIndexOf('\"');
            ModName = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

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
                throw new FileLoadException("ModDataBase error", new DescriptorInvalidException());

            // Check Mod Language folder
            for (int i = 0; i < 8; i++)
            {
                Language li = (Language)i;
                string folderPath = ModPath + "\\localisation\\" + ModLanguage.GetFolderName(li);
                if (Directory.Exists(folderPath))
                {
                    Folders.Add(li, new ModFolder(folderPath, this, loadFile));
                    Folders[li].IsOrigin = true;
                }
            }
            if (Folders.Count == 0)
                throw new FileLoadException("ModDataBase error", new DescriptorWithoutFoldersException());

            IsTranslateMod = isTranslate;
        }

        /// <summary>
        /// Get all <see cref="ModFolder"/> properties as an array.
        /// </summary>
        /// <returns>The array of ModFolders</returns>
        public ModFolder[] GetFolders()
        {
            Dictionary<Language, ModFolder>.ValueCollection folderValue = Folders.Values;
            List<ModFolder> folderArray = new List<ModFolder>();
            foreach (var folder in folderValue)
            {
                folderArray.Add(folder);
            }
            return folderArray.ToArray();
        }

        /// <summary>
        /// Add a <see cref="ModFolder"/> to database
        /// </summary>
        /// <param name="folderPath">The full path of Folder</param>
        /// <param name="language">The <see cref="Language"/> of localisation files in folder</param>
        /// <param name="loadFiles"><see langword="true"/>: Load localisation file; <see langword="false"/>: only create folder property</param>
        public void AddFolder(string folderPath,Language language, bool loadFiles)
        {
            ModFolder folder = new ModFolder(folderPath, this, loadFiles);
            Folders.Add(language, folder);
        }

        /// <summary>
        /// Generate a check file to save the currently mod data
        /// </summary>
        /// <param name="CheckFilePath">The full path of check file</param>
        public void GenerateCheckingFile(string CheckFilePath)
        {
            StreamWriter versionFile = new StreamWriter(CheckFilePath);
            versionFile.WriteLine(ModName);
            //versionFile.WriteLine(SupportVesrion);
            Dictionary<Language, ModFolder>.ValueCollection folderValues = Folders.Values;
            foreach (var folder in folderValues)
            {
                if (!folder.IsOrigin)
                    continue;
                versionFile.WriteLine($"<folder>");
                versionFile.WriteLine(folder.FolderLanguage.ToString());
                versionFile.WriteLine(folder.ModifyTime.ToString());
                Dictionary<string, ModFile>.ValueCollection fileValues = folder.Files.Values;
                foreach (var file in fileValues)
                {
                    versionFile.WriteLine($"<file>");
                    versionFile.WriteLine(file.Name);
                    //versionFile.WriteLine("<properties>");
                    Dictionary<string, ModProperty>.ValueCollection propertyValues = file.Properties.Values;
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

        /// <summary>
        /// Load checking file and save it as properties
        /// </summary>
        /// <param name="filePath">The full path of check file</param>
        /// <returns><see langword="true"/>: Load file successed. <see langword="false"/>Load file failed.</returns>
        public bool LoadCheckingFile(string filePath)
        {
            ModFolder folder;
            ModFile file;
            CheckingFolders = new Dictionary<Language, ModFolder>();
            CheckingProperties = new Dictionary<string, ModProperty>();
            if (File.Exists(filePath))
                return false;

            StreamReader CheckingFile = new StreamReader(filePath);
            string line = CheckingFile.ReadLine();
            if (line != ModName)
                return false;

            try
            {
                while (!CheckingFile.EndOfStream)
                {
                    line = CheckingFile.ReadLine();
                    if (line == "<folder>")
                    {
                        line = CheckingFile.ReadLine();
                        Language l = (Language)Enum.Parse(typeof(Language), line, true);
                        folder = new ModFolder(l, this);
                        CheckingFolders.Add(l, folder);
                        while (!CheckingFile.EndOfStream)
                        {
                            line = CheckingFile.ReadLine();
                            if (line == "<folder_end>")
                                break;
                            else if (line == "<file>")
                            {
                                line = CheckingFile.ReadLine();

                                file = new ModFile(line);
                                folder.AddFile(file);

                                while (!CheckingFile.EndOfStream)
                                {
                                    line = CheckingFile.ReadLine();
                                    if (line == "<file_end>")
                                        break;
                                    ModProperty property = new ModProperty(line, file);
                                    folder.Properties.Add(property.Name, property);

                                }
                            }
                        }
                    }
                }

                checkDataExsist = true;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CheckingFile.Close();
            }
        }

        /// <summary>
        /// Check localisation files were changed or not and tag the changed properties. 
        /// </summary>
        /// <returns><see langword="true"/>: The properties has been change.<see langword="false"/>: Nothing changed or check data doesn't exsist</returns>
        public bool CheckingVersion()
        {
            if (!checkDataExsist) 
                return false;

            //TODO: Mod checking

            bool versionChanged = false;

            return versionChanged;
        }
    }
}
