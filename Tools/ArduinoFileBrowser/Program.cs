/*=================================\
* ArduinoFileBrowser\Program.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.08.2017 20:09
* Last Edited: 18.08.2017 20:26:45
*=================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    static class Program
    {
        /// <summary>
        /// ?????????????? ?????????? ?????????? ?????? ????????????????????.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
