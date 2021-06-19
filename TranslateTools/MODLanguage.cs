using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranslateTools
{
    public enum Language { BrazPor, English, French, German, Polish, Russian, SimpleChinese, Spanish, Unknow }


    static class MODLanguage
    {
    #region Static Function
        public static string GetFolderName(Language language)
        {
            switch (language)
            {
                case Language.BrazPor:
                    return "braz_por";
                case Language.English:
                    return "english";
                case Language.French:
                    return "french";
                case Language.German:
                    return "german";
                case Language.Polish:
                    return "polish";
                case Language.Russian:
                    return "russian";
                case Language.SimpleChinese:
                    return "simp_chinese";
                case Language.Spanish:
                    return "spanish";
                default:
                    return "";
            }
        }

        public static string GetProperty(Language language)
        {
            switch (language)
            {
                case Language.BrazPor:
                    return "l_braz_por";
                case Language.English:
                    return "l_english";
                case Language.French:
                    return "l_french";
                case Language.German:
                    return "l_german";
                case Language.Polish:
                    return "l_polish";
                case Language.Russian:
                    return "l_russian";
                case Language.SimpleChinese:
                    return "l_simp_chinese";
                case Language.Spanish:
                    return "l_spanish";
                default:
                    return "";
            }
        }

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

        public static string PathChangeLanguage(string path, Language language)
        {
            int idx = path.IndexOf("\\localisation");
            string locFolder = path.Substring(0, idx - 1);
            int startIdx = path.LastIndexOf('\\') + 1;
            int endIdx = path.LastIndexOf("_l") - 1;
            string filename = path.Substring(startIdx, endIdx - startIdx);
            return locFolder + "\\" + GetFolderName(language) + "\\" + filename + "_" + GetProperty(language) + ".yml";
        }

        public static string PathGenerate(string folderPath, string fileName, Language language)
        {
            return folderPath + "\\" + GetProperty(language) + "\\" + fileName + "_" + GetProperty(language) + ".yml";
        }

        public static string GetMODFolder(string path)
        {
            int idx = path.IndexOf("\\localisation");
            return path.Substring(0, idx - 1);
        }

        public static string GetFileName(string filePath)
        {
            int startIdx = filePath.LastIndexOf('\\') + 1;
            int endIdx = filePath.LastIndexOf("_l") - 1;
            return filePath.Substring(startIdx, endIdx - startIdx);
        }

        public static Language GetFolderLanguage(string folderPath)
        {
            int startIdx = folderPath.LastIndexOf('\\') + 1;
            string name = folderPath.Substring(startIdx);
            switch (name)
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
        #endregion
    }
}
