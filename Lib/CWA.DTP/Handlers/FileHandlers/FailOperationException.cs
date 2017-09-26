/*=================================\
* CWA.DTP\FailOperationException.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 22.08.2017 20:09
* Last Edited: 20.09.2017 9:24:43
*=================================*/

using System;

namespace CWA.DTP
{
    public sealed class FailOperationException : Exception
    {
        public override string Message
        {
            get { return _Message; }
        }

        private string _Message;

        public object EnumStatus { get; }

        public FailOperationException() { }

        public FailOperationException(string Message)
        {
            _Message = Message;
        }

        public FailOperationException(object EnumMessage)
        {
            EnumStatus = EnumMessage;
        }

        public FailOperationException(string Message, object EnumMessage)
        {
            _Message = Message;
            EnumStatus = EnumMessage;
        }
    }
}
