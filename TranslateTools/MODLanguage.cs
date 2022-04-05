using System.IO;

namespace TranslateTools
{
    /// <summary>
    /// The enumerate of Stellaris Mod language
    /// </summary>
    public enum Language
    {
        Unknow,
        BrazPor,
        English,
        French,
        German,
        Polish,
        Russian,
        SimpleChinese,
        Spanish
    }

    public static class ModLanguage
    {
        private static string[] languageFolderName =
        {
            "unknow",
            "braz_por",
            "english",
            "french",
            "german",
            "polish",
            "russian",
            "simp_chinese",
            "spanish"
        };
        #region Static Function
        /// <summary>
        /// Get the language folder name string from <see cref="Language"/>
        /// </summary>
        /// <param name="language">The <see cref="Language"/> of <see cref="ModFolder"/></param>
        /// <returns>The language folder name string of <see cref="Language"/></returns>
        public static string GetFolderName(Language language)
        {
            return languageFolderName[(int)language];
        }

        /// <summary>
        /// Get the language property name string from <see cref="Language"/>
        /// </summary>
        /// <param name="language">The <see cref="Language"/> of property</param>
        /// <returns>The language property name string of <see cref="Language"/></returns>
        public static string GetProperty(Language language)
        {
            return "l_" + GetFolderName(language);
        }

        /// <summary>
        /// Get <see cref="Language"/> from the folder name
        /// </summary>
        /// <param name="folderPath">The path of folder</param>
        /// <returns>The <see cref="Language"/> of folder</returns>
        public static Language GetFolderLanguage(string folderPath)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            switch (folder.Name)
            {
                case "braz_por":
                    return Language.BrazPor;
                case "english":
                    return Language.English;
                case "french":
                    return Language.French;
                case "german":
                    return Language.German;
                case "polish":
                    return Language.Polish;
                case "russian":
                    return Language.Russian;
                case "simp_chinese":
                    return Language.SimpleChinese;
                case "spanish":
                    return Language.Spanish;
                default:
                    return Language.Unknow;
            }
        }

        /// <summary>
        /// Get the <see cref="Language"/> propety from property string
        /// </summary>
        /// <param name="name">The string name of <see cref="Language"/></param>
        /// <returns>The <see cref="Language"/> property</returns>
        public static Language GetLanguage(string name)
        {
            switch (name)
            {
                case "l_braz_por":
                    return Language.BrazPor;
                case "l_english":
                    return Language.English;
                case "l_french":
                    return Language.French;
                case "l_german":
                    return Language.German;
                case "l_polish":
                    return Language.Polish;
                case "l_russian":
                    return Language.Russian;
                case "l_simp_chinese":
                    return Language.SimpleChinese;
                case "l_spanish":
                    return Language.Spanish;
                default:
                    return Language.Unknow;
            }
        }

        /// <summary>
        /// Generate a new file path from <see cref="Language"/>
        /// </summary>
        /// <param name="filePath">The original file path</param>
        /// <param name="language">The new file path</param>
        /// <returns>The new full file path with <see cref="Language"/></returns>
        public static string FileLanguageChange(string filePath, Language language)
        {
            // Get path of localisation folder
            string locFolder = Directory.GetParent(filePath).Parent.FullName;
            // Get old folder language
            Language oldLanguage = GetFolderLanguage(Directory.GetParent(filePath).FullName);
            // Change language property in file name
            string fileName = Path.GetFileName(filePath);
            fileName = fileName.Replace(GetProperty(oldLanguage), GetProperty(language));
            return locFolder + "\\" + GetFolderName(language) + "\\" + fileName;
        }

        /// <summary>
        /// Generate a file path with the folder path, the file name, and the <see cref="Language"/>
        /// </summary>
        /// <param name="folderPath">The path of localisation folder</param>
        /// <param name="fileName">The file name without languagne property</param>
        /// <param name="language">The <see cref="Language"/> of file</param>
        /// <returns>The full file path</returns>
        public static string FilePathGenerate(string folderPath, string fileName, Language language)
        {
            Language oldLanguage;
            for (int i = 1; i < 8; i++)
            {
                oldLanguage = (Language)i;
                if (oldLanguage == language)
                    continue;
                fileName = fileName.Replace(GetProperty(oldLanguage), GetProperty(language));                
            }
            // Change language property in file name
            return folderPath + "\\" + GetFolderName(language) + "\\" + fileName;
        }

        /// <summary>
        /// Get the mod folder path
        /// </summary>
        /// <param name="path">The path of folder or file in mod folder</param>
        /// <returns>The path of mod folder</returns>
        /// <exception cref="LocalisationMissingException"></exception>
        public static string GetModFolder(string path)
        {
            if (path.IndexOf("\\localisation") < 0)
                throw new LocalisationMissingException();
            int idx = path.IndexOf("\\localisation");
            return path.Substring(0, idx - 1);
        }

        /// <summary>
        /// Get file name without language property
        /// </summary>
        /// <param name="filePath">The path of file</param>
        /// <returns>The file name without language property</returns>
        public static string GetFileName(string filePath)
        {
            // Get full file name
            string file = Path.GetFileName(filePath);
            // Get lenght of file name without language property
            int nameLength = file.LastIndexOf(".yml") - 1;
            // Return of file name without language property
            return file.Substring(0, nameLength);
        }
        #endregion
    }
}
