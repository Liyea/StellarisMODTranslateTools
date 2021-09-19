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
        public ModFolder Folder;
        public List<ModProperty> Lines;
        public Dictionary<string, ModProperty> Properties;
        public string FilePath;
        public string Name;
        public Language Language
        {
            get => Folder.Language;
        }
        public FileState State;
        public bool Exsit = true;

        public ModFile(string FileName)
        {
            Name = FileName;
            Lines = new List<ModProperty>();
            Properties = new Dictionary<string, ModProperty>();
        }

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
            if (fileLanguage != Folder.Language)
            {
                fileReader.Close();
                State = FileState.Error;
                return;
            }

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

        public void PathModify()
        {
            string folderPath = Folder.FolderPath;
            FilePath = folderPath + '\\' + Name + '_' + ModLanguage.GetProperty(Language) + ".yml";
        }

        public void FileGenerate()
        {
            if (Folder.IsOrigin)
                throw new Exception("You cannot generate file in original folder");
            StreamWriter writer = new StreamWriter(FilePath);
            for (int i = 0; i < Lines.Count; i++)
            {
                writer.WriteLine(Lines[i].GetLine());
            }
            writer.Close();
        }

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
