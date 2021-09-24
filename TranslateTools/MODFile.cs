using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum FileState { Unknow, Done, Modify, Error }

    public class ModFile
    {
        #region
        public ModFolder Folder;
        public List<ModProperty> Lines;
        public Dictionary<string, ModProperty> Properties;
        public string FilePath;
        public string Name;
        public Language Language
        {
            get => Folder.FolderLanguage;
        }
        public FileState State;
        public bool Exsit = true;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        public ModFile(string FileName)
        {
            Name = FileName;
            Lines = new List<ModProperty>();
            Properties = new Dictionary<string, ModProperty>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="parent"></param>
        public ModFile(string filePath, ModFolder parent)
        {
            // Initialize Dictionary
            Lines = new List<ModProperty>();
            Properties = new Dictionary<string, ModProperty>();

            // Set File Name
            int startIdx = filePath.LastIndexOf('\\') + 1;
            int endIdx = filePath.LastIndexOf('_') - 2;
            Name = filePath.Substring(startIdx, endIdx - startIdx);
            FilePath = filePath;
            Folder = parent;

            // Find File Language
            StreamReader fileReader = new StreamReader(filePath);
            string line = fileReader.ReadLine();
            Language fileLanguage = ModLanguage.GetLanguage(line.Remove(line.Length - 1));
            if (fileLanguage != Folder.FolderLanguage)
            {
                fileReader.Close();
                State = FileState.Error;
                return;
            }
            Folder.Mod.Files.Add(Name, this);

            // Add Properties
            ModProperty head = new ModProperty();
            head.Text = line;
            Lines.Add(head); 
            while (!fileReader.EndOfStream)
            {
                line = fileReader.ReadLine();
                ModProperty p = new ModProperty(line, this);
                Lines.Add(p);
                if (!p.IsNote)
                {
                    try
                    { 
                        Properties.Add(p.Name, p);
                        Folder.Mod.Properties.Add(p.Name, p);
                    }
                    catch(ArgumentException ex)
                    {
                        Properties[p.Name].State = PropertySate.MoreThanOne;
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            fileReader.Close();
            State = FileState.Done;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ModProperty[] GetProperties()
        {
            Dictionary<string, ModProperty>.ValueCollection propertyValues = Properties.Values;
            List<ModProperty> propertiesArray = new List<ModProperty>();
            foreach (var p in propertyValues)
            {
                propertiesArray.Add(p);
            }
            return propertiesArray.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public ModFile Clone(ModFolder folder)
        {
            ModFile cloneFile = (ModFile)MemberwiseClone();
            cloneFile.Folder = folder;            
            cloneFile.Properties.Clear();
            cloneFile.Lines.Clear();
            for (int i = 0; i < Lines.Count; i++)
            {
                ModProperty clonePropety = Lines[i].Clone(cloneFile);
                cloneFile.Lines.Add(clonePropety);
                if (!clonePropety.IsNote)
                    cloneFile.Properties.Add(clonePropety.Name, clonePropety);
            }
            cloneFile.Name = (string)Name.Clone();
            cloneFile.FilePath = (string)FilePath.Clone();
            State = FileState.Modify;
            Exsit = false;

            return cloneFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        public void PathGenerate()
        {
            string folderPath = Folder.FolderPath;
            FilePath = folderPath + '\\' + Name + '_' + ModLanguage.GetProperty(Language) + ".yml";
        }

        /// <summary>
        /// Generate a new file
        /// </summary>
        public void FileGenerate()
        {
            if (!Folder.Mod.IsTranslationMod)
                throw new Exception("You cannot generate file in original mod folder");
            StreamWriter writer = new StreamWriter(FilePath);
            for (int i = 0; i < Lines.Count; i++)
            {
                writer.WriteLine(Lines[i].GetLine());
            }
            writer.Close();
        }

        /// <summary>
        /// Copy <see cref="ModProperty"/> from another <see cref="ModFile"/>
        /// </summary>
        /// <param name="originalFile">The source <see cref="ModFile"/> of properties</param>
        public void CopyLines(ModFile originalFile) 
        {
            ModProperty head = Lines[0];
            Lines.Clear();
            Lines.Add(head);
            List<ModProperty> originalLins = originalFile.Lines;
            for (int i = 1; i < originalLins.Count; i++)
            {
                if (Properties.ContainsKey(originalLins[i].Name))
                    Lines.Add(Properties[originalLins[i].Name]);
                else
                {
                    ModProperty copyProperty = originalLins[i].Clone(this);
                    Lines.Add(copyProperty);
                }
            }
        }
    }
}
