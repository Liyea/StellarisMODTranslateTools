using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum PropertySate { Unknow, New, Missing, Modify, Done, Remove, MoreThanOne, FileModify }

    public class ModProperty
    {
        public string Name;
        public PropertySate State = PropertySate.Unknow;
        public Language Language
        {
            get => File.Language;
        }
        public bool IsNote = false;
        public ModFile File;
        public string Text;
        
        public ModProperty()
        {
            Name = "Language";
            Text = "";
            IsNote = true;
        }

        public ModProperty(string line, string fileName)
        {
            IsNote = (line.IndexOf("#") == 0) || (line.IndexOf(':') < 0);
            File = new ModFile(fileName);
            if (IsNote)
            {
                Text = line;
            }
            else
            {
                int EndIndex = line.IndexOf(":");
                Name = line.Substring(0, EndIndex);
                int StartIndex = line.IndexOf('\"');
                EndIndex = line.LastIndexOf('\"');
                Text = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);
            }
        }

        public ModProperty(string line, ModFile file)
        {
            File = file;
            IsNote = (line.IndexOf("#") == 0) || (line.IndexOf(':') < 0);
            if (IsNote)
            {
                Text = line;
            }
            else
            {
                int EndIndex = line.IndexOf(":");
                Name = line.Substring(0, EndIndex);
                int StartIndex = line.IndexOf('\"');
                EndIndex = line.LastIndexOf('\"');
                Text = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);
            }            
        }

        public PropertySate TextCheck(ModProperty other)
        {
            if (other.Name != Name)
                return PropertySate.Unknow;
            else if (other.Language != Language)
                return PropertySate.Unknow;
            else if (other.Text == Text)
                return PropertySate.Done;
            else if (other.File.Name != File.Name)
                return PropertySate.FileModify;
            else
                return PropertySate.Modify;
        }

        //public PropertySate StateCheck(MODProperty target)
        //{            
        //    if (Text == Text[originLanguage])
        //        State = PropertySate.Done;
        //    else
        //        State = PropertySate.Modify;
        //    return State;
        //}

        public string GetLine()
        {
            if (IsNote)
                return Text;
            else
                return Name + ":0 \"" + Text + '\"';
        }

        public ModProperty Clone(ModFile parent)
        {
            var cloneMODProperty = (ModProperty)MemberwiseClone();
            cloneMODProperty.Name = (string)Name.Clone();
            cloneMODProperty.State = PropertySate.Unknow;
            cloneMODProperty.File = parent;
            cloneMODProperty.Text = (string)Text.Clone();

            return cloneMODProperty;
        }
    }
}
