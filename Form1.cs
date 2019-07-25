﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialogDialog() { Filter = "JPEG|*.jpg", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    pictureBox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc_Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
    }
}
