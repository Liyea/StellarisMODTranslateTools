using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum FileState
    {
        Unknow,
        Done,
        Modify,
        Error
    }

    public class ModFile
    {
        #region Properties
        /// <summary>
        /// The <see cref="ModFolder"/> that the file belong to
        /// </summary>
        public ModFolder Folder;
        /// <summary>
        /// The original lines in the file
        /// </summary>
        public List<ModProperty> Lines;
        /// <summary>
        /// The properties in the file
        /// </summary>
        public Dictionary<string, ModProperty> Properties;
        /// <summary>
        /// The path of the file
        /// </summary>
        public string FilePath;
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name;
        /// <summary>
        /// The language of the file
        /// </summary>
        public Language Language
        {
            get => Folder.FolderLanguage;
        }
        /// <summary>
        /// The <see cref="FileState"/> of this <see cref="ModFile"/>
        /// </summary>
        public FileState State;
        /// <summary>
        /// <see langword="true"/>: the file is exsit        
        /// </summary>
        public bool Exsit = true;
        // full name of file
        //private string fullName;
        #endregion

        /// <summary>
        /// Generate a emtpy <see cref="ModFile"/> with a name
        /// </summary>
        /// <param name="FileName">The name of <see cref="ModFile"/></param>
        public ModFile(string FileName)
        {
            Name = FileName;
            //fullName = FileName;
            Lines = new List<ModProperty>();
            Properties = new Dictionary<string, ModProperty>();
            Exsit = false;
        }

        /// <summary>
        /// Generate the complete <see cref="ModFile"/> with file path and <see cref="ModFolder"/> parent
        /// </summary>
        /// <param name="filePath">The path of localisation file</param>
        /// <param name="parent">The <see cref="ModFolder"/> this file belong to</param>
        public ModFile(string filePath, ModFolder parent)
        {
            // Initialize Dictionary
            Lines = new List<ModProperty>();
            Properties = new Dictionary<string, ModProperty>();

            // Set File Name
            FilePath = filePath;
            Folder = parent;
            Name = ModLanguage.GetFileName(filePath);
            //int startIdx = filePath.LastIndexOf('\\') + 1;
            //fullName = filePath.Substring(startIdx);
            //int endIdx = filePath.LastIndexOf(".yml");
            //Name = (endIdx >= startIdx) ? filePath.Substring(startIdx, endIdx - startIdx) : fullName;


            // Find File Language
            StreamReader fileReader = new StreamReader(filePath);
            string line = fileReader.ReadLine();
            string strLanguage = line.Remove(line.Length - 1);
            Language fileLanguage = ModLanguage.GetLanguage(strLanguage);
            if (fileLanguage != Language)
            {
                fileReader.Close();
                State = FileState.Error;
                return;
            }
            Folder.Mod.Files.Add(Name, this);

            // Add Properties
            ModProperty head = new ModProperty
            {
                Content = line
            };
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
                    catch (ArgumentException ex)
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
        /// Get all <see cref="ModProperty"/> properties as an array.
        /// </summary>
        /// <returns>The array of <see cref="ModProperty"/></returns>
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
        /// Clone this <see cref="ModFile"/> to the <see cref="ModFolder"/>
        /// </summary>
        /// <param name="folder">The <see cref="ModFolder"/> that the cloned <see cref="ModFile"/> belong to</param>
        /// <returns> The cloned <see cref="ModFile"/></returns>
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
        /// Generate the path of the file
        /// </summary>
        /// <param name="folderPath"></param>
        public void PathGenerate()
        {
            string folderPath = Folder.FolderPath;
            FilePath = folderPath + '\\' + Name + ".yml";
        }

        /// <summary>
        /// Generate a new file
        /// </summary>
        public void FileGenerate()
        {
            if (!Folder.Mod.IsTranslationMod)
                throw new Exception("You cannot generate file in original mod folder");
            PathGenerate();
            StreamWriter writer = new StreamWriter(FilePath);
            for (int i = 0; i < Lines.Count; i++)
            {
                writer.WriteLine(Lines[i].GetLine());
            }
            writer.Close();
            Exsit = true;
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
