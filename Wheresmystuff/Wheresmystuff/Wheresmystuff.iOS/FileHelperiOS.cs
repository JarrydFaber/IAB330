using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Wheresmystuff.Interfaces;
using System.IO;

namespace Wheresmystuff.iOS
{
    public class FileHelperiOS : IFileHelper
    {
        public string GetLocalpath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libfolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if(!Directory.Exists(libfolder))
            {
                Directory.CreateDirectory(libfolder);

            }

            return Path.Combine(libfolder, filename);
        }    
    }
}