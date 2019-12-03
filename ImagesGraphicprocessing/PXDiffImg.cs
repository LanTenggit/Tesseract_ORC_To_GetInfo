using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesGraphicprocessing
{
    public partial class PXDiffImg : Form
    {
        public PXDiffImg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Contrast_picturePath = Path.GetFullPath("images");
            Contrast_picturePath += "\\11.png";

            string Contrast_picturePath1 = Path.GetFullPath("images");
            Contrast_picturePath1 += "\\11.png";




          byte [] imgbyte  =  FunctionClass.GetImageByte(Contrast_picturePath);
          byte [] imgbyte1 =  FunctionClass.GetImageByte(Contrast_picturePath1);


            string imgstr = FunctionClass.ByteArrayToHexString(imgbyte);
            string imgstr1 = FunctionClass.ByteArrayToHexString(imgbyte1);


            if (imgstr.Contains(imgstr1))
            {
                MessageBox.Show("图片存在！");
            }


          








        }

       






    }
}
