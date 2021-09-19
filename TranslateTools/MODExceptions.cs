using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TranslateTools
{
    public class DescriptorMissingException: Exception
    {
        public DescriptorMissingException():base("The Descriptor file of mod doesn't exist.")
        {
            
        }
    }

    public class DescriptorInvalidException : Exception
    {
        public DescriptorInvalidException ():base("This is not a descriptor file of Stellaris mod.")
        {

        }
    }


    public class DescriptorWithoutFoldersException : Exception
    {
        public DescriptorWithoutFoldersException ():base("This mod doesn't have localisation files.")
        {

        }
    }
}
