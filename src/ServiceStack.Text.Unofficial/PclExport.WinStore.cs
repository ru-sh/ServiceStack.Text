//Copyright (c) Service Stack LLC. All Rights Reserved.
//License: https://raw.github.com/ServiceStack/ServiceStack/master/license.txt

#if NETFX_CORE
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ServiceStack
{
    public class WinStorePclExport : PclExport
    {
        public new static WinStorePclExport Provider = new WinStorePclExport();

        public WinStorePclExport()
        {
            this.PlatformName = Platforms.WindowsStore;
        }

        public static PclExport Configure()
        {
            Configure(Provider);
            return Provider;
        }

        public override string ReadAllText(string filePath)
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var fileStream = isoStore.OpenFile(filePath, FileMode.Open))
                {
                    return new StreamReader(fileStream).ReadToEnd();
                }
            }
        }

        public override bool FileExists(string filePath)
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return isoStore.FileExists(filePath);
            }
        }

        public override void WriteLine(string line)
        {
            System.Diagnostics.Debug.WriteLine(line);
        }

        public override void WriteLine(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format, args);
        }
    }
}

#endif
