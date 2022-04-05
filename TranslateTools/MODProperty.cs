using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum PropertySate
    {
        Unknow,
        New,
        Missing,
        Modify,
        Done,
        Remove,
        MoreThanOne,
        FileModify
    }

    public class ModProperty
    {
        #region
        /// <summary>
        /// The name of property
        /// </summary>
        public string Name;
        /// <summary>
        /// The state of this property
        /// </summary>
        public PropertySate State = PropertySate.Unknow;
        /// <summary>
        /// The language of this proerty
        /// </summary>
        public Language Language
        {
            get => File.Language;
        }
        /// <summary>
        /// <see langword="true"/> This is a line of note
        /// </summary>
        public bool IsNote
        {
            get => isNote;
        }
        /// <summary>
        /// The file this proprety belong
        /// </summary>
        public ModFile File;
        /// <summary>
        /// The content of proprety, will dispaly newlines
        /// </summary>
        public string Content
        {
            get => content;
            set
            {
                SetContent(value);
            }
        }
        /// <summary>
        /// The content displayed in the game, will display multiple lines
        /// </summary>
        public string DisplayContent
        {
            get => displayContent;
            set
            {
                SetDisplayContent(value);
            }
        }

        private string content;
        private string displayContent;
        private bool isNote = false;
        #endregion

        /// <summary>
        /// Create a empty property
        /// </summary>
        public ModProperty()
        {
            Name = "Language";
            Content = "";
            isNote = true;
        }

        /// <summary>
        /// Record the content of property and create a ModFile class
        /// </summary>
        /// <param name="content">The recorded content of property</param>
        /// <param name="fileName">The name of created file</param>
        public ModProperty(string content, string fileName)
        {
            isNote = (content.IndexOf("#") == 0) || (content.IndexOf(':') < 0);
            File = new ModFile(fileName);
            if (IsNote)
            {
                Content = content;
            }
            else
            {
                int EndIndex = content.IndexOf(":");
                Name = content.Substring(0, EndIndex);
                int StartIndex = content.IndexOf('\"');
                EndIndex = content.LastIndexOf('\"');
                Content = content.Substring(StartIndex + 1, EndIndex - StartIndex - 1);
            }
        }

        /// <summary>
        /// Record a property and the file that property belong to
        /// </summary>
        /// <param name="line">The recorded text of property</param>
        /// <param name="file">The file this property belong to</param>
        public ModProperty(string line, ModFile file)
        {
            File = file;
            isNote = (line.IndexOf("#") == 0) || (line.IndexOf(':') < 0);
            if (IsNote)
            {
                Content = line;
            }
            else
            {
                int EndIndex = line.IndexOf(":");
                Name = line.Substring(0, EndIndex);
                int StartIndex = line.IndexOf('\"');
                EndIndex = line.LastIndexOf('\"');
                Content = line.Substring(StartIndex + 1, EndIndex - StartIndex - 1);
            }
        }

        /// <summary>
        /// Compare this property and another one
        /// </summary>
        /// <param name="other">The property compared</param>
        /// <returns>The result of compare</returns>
        public PropertySate TextCheck(ModProperty other)
        {
            if (other.Name != Name)
                return PropertySate.Unknow;
            else if (other.Language != Language)
                return PropertySate.Unknow;
            else if (other.Content == Content)
                return PropertySate.Done;
            else if (other.File.Name != File.Name)
                return PropertySate.FileModify;
            else
                return PropertySate.Modify;
        }

        /// <summary>
        /// Generate full text of property, include property name and text
        /// </summary>
        /// <returns>The full text of property</returns>
        public string GetLine()
        {
            if (IsNote)
                return Content;
            else
                return $"{Name}:0 \"{Content}\"";
        }

        /// <summary>
        /// Clone the property to another <see cref="ModFile"/>
        /// </summary>
        /// <param name="parent">The file new property belong to</param>
        /// <returns>The cloned <see cref="ModProperty"/></returns>
        public ModProperty Clone(ModFile parent)
        {
            var cloneMODProperty = (ModProperty)MemberwiseClone();
            cloneMODProperty.Name = (string)Name.Clone();
            cloneMODProperty.State = PropertySate.Unknow;
            cloneMODProperty.File = parent;
            cloneMODProperty.Content = (string)Content.Clone();

            return cloneMODProperty;
        }

        private void SetContent(string content)
        {
            this.content = content;
            displayContent = content.Replace("\\n", "\n");
        }
        private void SetDisplayContent(string displayContent)
        {
            this.displayContent = displayContent;
            content = displayContent.Replace("\n", "\\n");
        }
    }
}
