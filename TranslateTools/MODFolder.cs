using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public class MODFolder
    {
        public string Path;
        public Dictionary<string, MODFile> Files;
        public Dictionary<string, MODProperty> Properties;        
        public Language Language;
        public string[] FilePathList;
        public DateTime ModifyTime;
        public MODDataBase MOD;
        public bool IsOrigin = false;

        public MODFolder()
        {
            Files = new Dictionary<string, MODFile>();
            Properties = new Dictionary<string, MODProperty>();
        }

        public MODFolder(Language language, MODDataBase parent)
        {
            Files = new Dictionary<string, MODFile>();
            Properties = new Dictionary<string, MODProperty>();
            Language = language;
            MOD = parent;
        }

        public MODFolder(string folderPath, MODDataBase parent, bool loadFiles)
        {
            Path = folderPath;
            Files = new Dictionary<string, MODFile>();
            Properties = new Dictionary<string, MODProperty>();
            Language = MODLanguage.GetFolderLanguage(folderPath);
            FilePathList = Directory.GetFiles(folderPath);
            MOD = parent;
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
                MODFile file = new MODFile(filePath, this);
                Files.Add(file.Name, file);
                Dictionary<string, MODProperty>.ValueCollection properties = file.Properties.Values;
                foreach (var p in properties)
                {
                    Properties.Add(p.Name, p);
                }
            }
        }

        public MODFile[] GetFiles()
        {
            Dictionary<string, MODFile>.ValueCollection filesValue = Files.Values;
            List<MODFile> filesArray = new List<MODFile>();
            foreach (var file in filesValue)
            {
                filesArray.Add(file);
            }
            return filesArray.ToArray();
        }

        public void AddFile(MODFile file)
        {
            Files.Add(file.Name, file);
            file.Folder = this;
        }

        public MODFolder Clone(MODDataBase database, Language language, string folderPath)
        {
            MODFolder cloneFolder = (MODFolder)MemberwiseClone();
            cloneFolder.Path = folderPath;
            cloneFolder.Files.Clear();
            cloneFolder.MOD = database;
            cloneFolder.Language = language;
            List<string> fileList = new List<string>();
            Dictionary<string, MODFile>.ValueCollection files = Files.Values;
            foreach (var f in files)
            {
                MODFile cloneFile = f.Clone(cloneFolder);
                cloneFile.PathModify();
                cloneFolder.Files.Add(cloneFile.Name, cloneFile);
                fileList.Add(cloneFile.Path);
            }
            cloneFolder.FilePathList = fileList.ToArray();
            cloneFolder.IsOrigin = false;
            return cloneFolder;
        }
    }
}
