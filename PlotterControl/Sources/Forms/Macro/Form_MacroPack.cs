/*=================================\
* PlotterControl\Form_MacroPack.cs
*
* The Coestaris licenses this file to you under the MIT license.
* See the LICENSE file in the project root for more information.
*
* Created: 06.08.2017 19:55
* Last Edited: 18.08.2017 20:26:47
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
