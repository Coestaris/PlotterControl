/*=================================\
* CWA.DTP\FileInfo.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using System;

namespace CWA.DTP
{
    public class SdCardDirectoryFileInfo
    {
        public int FileDirectorySize { get; internal set; }
        public DateTime CreationTime { get; internal set; }
        public bool IsHidden { get; internal set; }
        public bool IsLFN { get; internal set; }
        public bool IsReadOnly { get; internal set; }
        public bool IsDirectory { get; internal set; }
        public bool IsSystem { get; internal set; }
        public string Name { get; internal set; }

        internal SdCardDirectoryFileInfo() { }

        public override string ToString()
        {
            string res = "";
            res += string.Format("File: {0}\n", Name);
            res += string.Format("Size: {0}\n", FileDirectorySize);
            res += string.Format("CreationTime: {0}\n", CreationTime.ToString());
            res += string.Format("IsHidden: {0}\n", IsHidden);
            res += string.Format("IsLFN: {0}\n", IsLFN);
            res += string.Format("IsReadOnly: {0}\n", IsReadOnly);
            res += string.Format("IsDir: {0}\n", IsDirectory);
            res += string.Format("IsSystem: {0}\n", IsSystem);
            return res;
        }
    }
}
