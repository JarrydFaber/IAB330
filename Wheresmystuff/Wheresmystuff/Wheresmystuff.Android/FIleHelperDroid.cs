﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Wheresmystuff.Interfaces;
using System.IO;

namespace Wheresmystuff.Droid
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalpath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);

        }
    }
}