using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum PropertySate { Unknow, New, Missing, Modify, Done, Remove, MoreThanOne }

    public class MODProperty
    {
        public string Name;
        public PropertySate State = PropertySate.Unknow;
        public Language Language
        {
            get => File.Language;
        }
        public bool IsNote = false;
        public MODFile File;
        public string Text;
        
        public MODProperty()
        {
            Name = "Language";
            Text = "";
            IsNote = true;
        }

        public MODProperty(string line, MODFile file)
        {
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
                File = file;
            }            
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

        public MODProperty Clone(MODFile parent)
        {
            var cloneMODProperty = (MODProperty)MemberwiseClone();
            cloneMODProperty.Name = (string)Name.Clone();
            cloneMODProperty.State = PropertySate.Unknow;
            cloneMODProperty.File = parent;
            cloneMODProperty.Text = (string)Text.Clone();

            return cloneMODProperty;
        }
    }
}
