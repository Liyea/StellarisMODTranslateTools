using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TranslateTools
{
    public class ModDataBase
    {
        #region Properties
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
        public bool IsTranslationMod { get; }
        /// <summary>
        /// The last modify time of mod
        /// </summary>
        public DateTime ModifyTime;

        // The folders of checking version
        private Dictionary<Language, ModFolder> CheckingFolders;
        // The files of checking version
        private Dictionary<string, ModFile> ChecknigFiles;
        // The properties of checking version        
        private Dictionary<string, ModProperty> CheckingProperties;
        private bool checkDataExist = false;
        #endregion

        #region Constructor Methods
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
            IsTranslationMod = true;
        }

        /// <summary>
        /// Generate a new Mod with descriptor and folders
        /// </summary>
        /// <param name="modFolderPath">The full path of mod folder</param>
        /// <param name="modName">The name of new mod</param>
        public ModDataBase(string modFolderPath, string modName)
        {
            // TODO: Mod generator
            ModName = modName;
            Folders = new Dictionary<Language, ModFolder>();
            Properties = new Dictionary<string, ModProperty>();
            StreamWriter Descriptor = new StreamWriter(modFolderPath + "\\descriptor.mod");
            Descriptor.WriteLine();
            IsTranslationMod = true;
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
            ModifyTime = DateTime.MinValue;

            //Find descriptor file            
            if (!File.Exists(descriptorPath))
                throw new FileLoadException(nameof(ModDataBase) + " error", new DescriptorMissingException());
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
                throw new FileLoadException(nameof(ModDataBase) + " error", new DescriptorInvalidException());

            // Check Mod Language folder
            for (int i = 0; i < 8; i++)
            {
                Language li = (Language)i;
                string folderPath = ModPath + "\\localisation\\" + ModLanguage.GetFolderName(li);
                if (Directory.Exists(folderPath))
                {
                    ModFolder folder = new ModFolder(folderPath, this, loadFile);
                    Folders.Add(li, folder);
                    if (ModifyTime.CompareTo(folder.ModifyTime) < 0)
                        ModifyTime = folder.ModifyTime;
                }
            }
            if (Folders.Count == 0)
                throw new FileLoadException(nameof(ModDataBase) + " error", new LocalisationMissingException());

            IsTranslationMod = isTranslate;
        }
        #endregion

        #region Get Array Methods
        /// <summary>
        /// Get all <see cref="ModFolder"/> properties as an array.
        /// </summary>
        /// <returns>The array of <see cref="ModFolder"/></returns>
        public ModFolder[] GetFolders()
        {
            Dictionary<Language, ModFolder>.ValueCollection folderValue = Folders.Values;
            List<ModFolder> folderList = new List<ModFolder>();
            foreach (var folder in folderValue)
            {
                folderList.Add(folder);
            }
            return folderList.ToArray();
        }

        /// <summary>
        /// Get all <see cref="ModFile"/> properties as an array.
        /// </summary>
        /// <returns>The array of <see cref="ModFile"/></returns>
        public ModFile[] GetFiles()
        {
            var fileValue = Files.Values;
            List<ModFile> fileList = new List<ModFile>();
            foreach (var file in fileValue)
            {
                fileList.Add(file);
            }
            return fileList.ToArray();
        }

        /// <summary>
        /// Get all <see cref="ModProperty"/> properties as an array.
        /// </summary>
        /// <returns>The array of <see cref="ModProperty"/></returns>
        public ModProperty[] GetProperties()
        {
            var propertyValue = Properties.Values;
            List<ModProperty> propertyList = new List<ModProperty>();
            foreach (var property in propertyValue)
            {
                propertyList.Add(property);
            }
            return propertyList.ToArray();
        }
        #endregion

        #region Translation Methods
        /// <summary>
        /// Add a <see cref="ModFolder"/> to database
        /// </summary>
        /// <param name="folderPath">The full path of Folder</param>
        /// <param name="language">The <see cref="Language"/> of localisation files in folder</param>
        /// <param name="loadFiles"><see langword="true"/>: Load localisation file; <see langword="false"/>: only create folder property</param>
        public void AddFolder(string folderPath, Language language, bool loadFiles)
        {
            ModFolder folder = new ModFolder(folderPath, this, loadFiles);
            Folders.Add(language, folder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Translation"></param>
        public void CheckingTranslation(ModDataBase Translation)
        {

        }
        #endregion

        #region Checking Version Methods
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
                versionFile.WriteLine($"folder=" + ModLanguage.GetFolderName(folder.FolderLanguage));
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
        /// Load checking file
        /// </summary>
        /// <param name="filePath">The full path of check file</param>
        /// <returns><see langword="true"/>: Load file successed. <see langword="false"/>Load file failed.</returns>
        public bool LoadCheckingFile(string filePath)
        {
            CheckingFolders = new Dictionary<Language, ModFolder>();
            ChecknigFiles = new Dictionary<string, ModFile>();
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
                        ModFolder modFolder = new ModFolder(l, this);
                        CheckingFolders.Add(l, modFolder);
                        while (!CheckingFile.EndOfStream)
                        {
                            line = CheckingFile.ReadLine();
                            if (line == "<folder_end>")
                                break;
                            else if (line == "<file>")
                            {
                                line = CheckingFile.ReadLine();

                                ModFile modFile = new ModFile(line);
                                modFolder.AddFile(modFile);

                                while (!CheckingFile.EndOfStream)
                                {
                                    line = CheckingFile.ReadLine();
                                    if (line == "<file_end>")
                                        break;
                                    ModProperty modProperty = new ModProperty(line, modFile);
                                    modFolder.Properties.Add(modProperty.Name, modProperty);
                                }
                            }
                        }
                    }
                }

                checkDataExist = true;
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
        /// Compare the files in mod with checking data and update the state of properties
        /// </summary>
        /// <returns><see langword="true"/>: The properties has been change.<see langword="false"/>: Nothing changed or check data doesn't exsist</returns>
        public bool CheckingVersion()
        {
            if (!checkDataExist)
                return false;
            bool versionChanged = false;

            //TODO: Mod checking
            //foreach()


            return versionChanged;
        }
        #endregion
    }
}
