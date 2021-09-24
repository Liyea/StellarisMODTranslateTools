using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TranslateTools
{
    /// <summary>
    /// The exception that <see cref="ModDataBase"/> can't find the mod descriptor file
    /// </summary>
    public class DescriptorMissingException: Exception
    {
        public DescriptorMissingException():base("The Descriptor file of mod doesn't exist.")
        {
            
        }
    }

    /// <summary>
    /// The exception that the descriptor file doesn't include necessary information of Stellaris mod
    /// </summary>
    public class DescriptorInvalidException : Exception
    {
        public DescriptorInvalidException ():base("This is not a descriptor file of Stellaris mod.")
        {

        }
    }

    /// <summary>
    /// The exception that <see cref="ModDataBase"/> can't find the localisation folder
    /// </summary>
    public class LocalisationMissingException : Exception
    {
        public LocalisationMissingException ():base("This mod doesn't have localisation files.")
        {

        }
    }
}
