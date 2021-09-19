using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public class ModFolder
    {
        public string FolderPath;
        public Dictionary<string, ModFile> Files;
        public Dictionary<string, ModProperty> Properties;        
        public Language Language;
        public string[] FilePathList;
        public DateTime ModifyTime;
        public ModDataBase Mod;
        public bool IsOrigin = false;

        public ModFolder()
        {
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
        }

        public ModFolder(Language language, ModDataBase parent)
        {
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
            Language = language;
            Mod = parent;
        }

        public ModFolder(string folderPath, ModDataBase parent, bool loadFiles)
        {
            FolderPath = folderPath;
            Files = new Dictionary<string, ModFile>();
            Properties = new Dictionary<string, ModProperty>();
            Language = ModLanguage.GetFolderLanguage(folderPath);
            FilePathList = Directory.GetFiles(folderPath);
            Mod = parent;
            if (loadFiles)
                LoadFiles();
        }

        public void LoadFiles()
        {
            Files.Clear();
            Properties.Clear();
            ModifyTime = DateTime.MinValue;
            foreach (var filePath in FilePathList)
            {
                DateTime fileTime = File.GetLastWriteTime(filePath);
                if (ModifyTime.CompareTo(fileTime) > 0)
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

        public void AddFile(ModFile file)
        {
            Files.Add(file.Name, file);
            file.Folder = this;
            file.PathModify();
        }

        public void AddFile(string fileName)
        {
            ModFile file = new ModFile(fileName);            
            AddFile(file);
        }

        public ModFolder Clone(ModDataBase database, Language language, string folderPath)
        {
            ModFolder cloneFolder = (ModFolder)MemberwiseClone();
            cloneFolder.FolderPath = folderPath;
            cloneFolder.Files.Clear();
            cloneFolder.Mod = database;
            cloneFolder.Language = language;
            List<string> fileList = new List<string>();
            Dictionary<string, ModFile>.ValueCollection files = Files.Values;
            foreach (var f in files)
            {
                ModFile cloneFile = f.Clone(cloneFolder);
                cloneFile.PathModify();
                cloneFolder.Files.Add(cloneFile.Name, cloneFile);
                fileList.Add(cloneFile.FilePath);
            }
            cloneFolder.FilePathList = fileList.ToArray();
            cloneFolder.IsOrigin = false;
            return cloneFolder;
        }
    }
}
