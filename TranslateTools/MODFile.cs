using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum FileState { Unknow, Done, Modify, Error }

    public class MODFile
    {
        public MODFolder Folder;
        public List<MODProperty> Lines;
        public Dictionary<string, MODProperty> Properties;
        public string FilePath;
        public string Name;
        public Language Language
        {
            get => Folder.Language;
        }
        public FileState State;
        public bool Exsit = true;

        public MODFile(string FileName)
        {
            Name = FileName;
            Lines = new List<MODProperty>();
            Properties = new Dictionary<string, MODProperty>();
        }

        public MODFile(string filePath, MODFolder parent)
        {
            // Initialize Dictionary
            Lines = new List<MODProperty>();
            Properties = new Dictionary<string, MODProperty>();

            // Set File Name
            int startIdx = filePath.LastIndexOf('\\') + 1;
            int endIdx = filePath.LastIndexOf('_') - 2;
            Name = filePath.Substring(startIdx, endIdx - startIdx);
            FilePath = filePath;
            Folder = parent;

            // Find File Language
            StreamReader fileReader = new StreamReader(filePath);
            string line = fileReader.ReadLine();
            Language fileLanguage = MODLanguage.GetLanguage(line.Remove(line.Length - 1));
            if (fileLanguage != Folder.Language)
            {
                fileReader.Close();
                State = FileState.Error;
                return;
            }

            // Add Properties
            MODProperty head = new MODProperty();
            head.Text = line;
            Lines.Add(head); 
            while (!fileReader.EndOfStream)
            {
                line = fileReader.ReadLine();
                MODProperty p = new MODProperty(line, this);
                Lines.Add(p);
                if (!p.IsNote)
                {
                    try
                    { 
                        Properties.Add(p.Name, p);
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

        public MODProperty[] GetProperties()
        {
            Dictionary<string, MODProperty>.ValueCollection propertyValues = Properties.Values;
            List<MODProperty> propertiesArray = new List<MODProperty>();
            foreach (var p in propertyValues)
            {
                propertiesArray.Add(p);
            }
            return propertiesArray.ToArray();
        }

        public MODFile Clone(MODFolder folder)
        {
            MODFile cloneFile = (MODFile)MemberwiseClone();
            cloneFile.Folder = folder;            
            cloneFile.Properties.Clear();
            cloneFile.Lines.Clear();
            for (int i = 0; i < Lines.Count; i++)
            {
                MODProperty clonePropety = Lines[i].Clone(cloneFile);
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
            FilePath = folderPath + '\\' + Name + '_' + MODLanguage.GetProperty(Language) + ".yml";
        }

        public void FileGenerate()
        {
            if (Folder.IsOrigin)
                throw new AccessViolationException("You can generate original file");
            StreamWriter writer = new StreamWriter(FilePath);
            for (int i = 0; i < Lines.Count; i++)
            {
                writer.WriteLine(Lines[i].GetLine());
            }
            writer.Close();
        }

        public void CopyLines(MODFile originalFile) 
        {
            MODProperty head = Lines[0];
            Lines.Clear();
            Lines.Add(head);
            List<MODProperty> originalLins = originalFile.Lines;
            for (int i = 1; i < originalLins.Count; i++)
            {
                if (Properties.ContainsKey(originalLins[i].Name))
                    Lines.Add(Properties[originalLins[i].Name]);
                else
                {
                    MODProperty copyProperty = originalLins[i].Clone(this);
                    Lines.Add(copyProperty);
                }
            }
        }
    }
}
