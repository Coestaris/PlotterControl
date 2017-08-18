/*
	The MIT License(MIT)

	Copyright(c) 2016 - 2017 Kurylko Maxim Igorevich

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:


	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.


	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

/*=================================\
* CWA.DTP \ FileInfo.cs
*
* Created: 06.08.2017 20:08
* Last Edited: 18.08.2017 20:21:24
*
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
