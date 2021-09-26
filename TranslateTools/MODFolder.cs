using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public class ModFolder
    {
        #region
        /// <summary>
        /// The path of this folder
        /// </summary>
        public string FolderPath;
        /// <summary>
        /// The <see cref="ModFile"/> belong to this folder
        /// </summary>
        public Dictionary<string, ModFile> Files;
        /// <summary>
        /// The <see cref="ModProperty"/> belong to files in this folder
        /// </summary>
        public Dictionary<string, ModProperty> Properties;
        /// <summary>
        /// The <see cref="Language"/> of this folder
        /// </summary>
        public Language FolderLanguage;
        /// <summary>
        /// The path of each file
        /// </summary>
        public string[] FilePathList;
        /// <summary>
        /// The last modify time of all files
        /// </summary>
        public DateTime ModifyTime;
        /// <summary>
        /// The mod this folder belong to
        /// </summary>
        public ModDataBase Mod;
        #endregion

        #region Constructor Methods
        /// <summary>
        /// Create a empty folder
        /// </summary>
        public ModFolder()
        {
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
        }

        /// <summary>
        /// Create a language folder for a <see cref="ModDataBase"/>.
        /// </summary>
        /// <param name="language">The <see cref="Language"/> of this folder</param>
        /// <param name="parent">The <see cref="ModDataBase"/> this folder belong to</param>
        public ModFolder(Language language, ModDataBase parent)
        {
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
            FolderLanguage = language;
            Mod = parent;
        }

        /// <summary>
        /// Load a language folder in a <see cref="ModDataBase"/>.
        /// </summary>
        /// <param name="folderPath">The path of folder</param>
        /// <param name="parent">The <see cref="ModDataBase"/> this folder belong to</param>
        /// <param name="loadFiles"><see langword="true"/>: Load files during construct; <see langword="false"/>: Only create folder</param>
        public ModFolder(string folderPath, ModDataBase parent, bool loadFiles)
        {
            FolderPath = folderPath;
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
            FolderLanguage = ModLanguage.GetFolderLanguage(folderPath);
            FilePathList = Directory.GetFiles(folderPath);
            Mod = parent;
            if (loadFiles)
                LoadFiles();
        }
        #endregion

        /// <summary>
        /// Load all of files in folder
        /// </summary>
        public void LoadFiles()
        {
            Files.Clear();
            Properties.Clear();
            ModifyTime = DateTime.MinValue;
            foreach (var filePath in FilePathList)
            {
                DateTime fileTime = File.GetLastWriteTime(filePath);
                if (ModifyTime.CompareTo(fileTime) < 0)
                    ModifyTime = fileTime;
                ModFile file = new ModFile(filePath, this);
                Files.Add(file.Name, file);
                Dictionary<string, ModProperty>.ValueCollection properties = file.Properties.Values;
                foreach (var p in properties)
                {
                    Properties.Add(p.Name, p);
                }
            }
        }

        /// <summary>
        /// Get all <see cref="ModFile"/> as a array
        /// </summary>
        /// <returns>The array of <see cref="ModFile"/></returns>
        public ModFile[] GetFiles()
        {
            Dictionary<string, ModFile>.ValueCollection filesValue = Files.Values;
            List<ModFile> filesArray = new List<ModFile>();
            foreach (var file in filesValue)
            {
                filesArray.Add(file);
            }
            return filesArray.ToArray();
        }

        /// <summary>
        /// Add a <see cref="ModFile"/> to folder
        /// </summary>
        /// <param name="file">The <see cref="ModFile"/> property added to folder</param>
        public void AddFile(ModFile file)
        {
            Files.Add(file.Name, file);
            file.Folder = this;
            file.PathGenerate();
        }

        /// <summary>
        /// Create a <see cref="ModFile"/> and add to folder
        /// </summary>
        /// <param name="fileName">The name of <see cref="ModFile"/> added to folder</param>
        public void AddFile(string fileName)
        {
            ModFile file = new ModFile(fileName);            
            AddFile(file);
        }

        /// <summary>
        /// Clone this folder to another <see cref="modd"/>
        /// </summary>
        /// <param name="database">The <see cref="ModDataBase"/> this folder belong to</param>
        /// <param name="language">The <see cref="Language"/> of this folder</param>
        /// <param name="folderPath">The path of cloned folder</param>
        /// <returns>The cloned <see cref="ModFolder"/></returns>
        public ModFolder Clone(ModDataBase database, Language language, string folderPath)
        {
            ModFolder cloneFolder = (ModFolder)MemberwiseClone();
            cloneFolder.FolderPath = folderPath;
            cloneFolder.Files.Clear();
            cloneFolder.Mod = database;
            cloneFolder.FolderLanguage = language;
            List<string> fileList = new List<string>();
            Dictionary<string, ModFile>.ValueCollection files = Files.Values;
            foreach (var f in files)
            {
                ModFile cloneFile = f.Clone(cloneFolder);
                cloneFile.PathGenerate();
                cloneFolder.Files.Add(cloneFile.Name, cloneFile);
                fileList.Add(cloneFile.FilePath);
            }
            cloneFolder.FilePathList = fileList.ToArray();
            return cloneFolder;
        }

        public override string ToString()
        {            
            return ModLanguage.GetFolderName(FolderLanguage);
        }
    }
}
