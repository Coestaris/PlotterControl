/*=================================\
* ArduinoFileBrowser\Program.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.08.2017 20:09
* Last Edited: 09.09.2017 21:10:45
*=================================*/

using System;
using System.Windows.Forms;

namespace FileBrowser
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectPortForm());
        }
    }
}
