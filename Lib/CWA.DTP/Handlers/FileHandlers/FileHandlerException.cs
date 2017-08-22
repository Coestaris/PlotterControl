/*=================================\
* CWA.DTP\FileHandlerException.cs
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
    public class FileHandlerException : Exception
    {
        private string _Message;

        public override string Message
        {
            get { return _Message; }
        }

        public FileHandlerException(string Message)
        {
            _Message = Message;
        }

        public FileHandlerException() { }
    }
}
