/*=================================\
* PlotterControl\Form_MacroPack.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 25.08.2017 22:27
* Last Edited: 19.08.2017 7:38:22
*=================================*/

using CWA;
using CWA.Vectors;
using CWA.Printing.Macro;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace CnC_WFA
{
    public partial class Form_MacroPack : Form
    {
        public Form_MacroPack()
        {
            InitializeComponent();
            Main = new MacroPack();
        }

        public MacroPack Main;

        private void button_main_device_col_Click(object sender, EventArgs e)
        {
            new Form_Dialog_MacroPackEdit().ShowDialog();
        }
    }
}
