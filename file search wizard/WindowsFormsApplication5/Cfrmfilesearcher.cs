using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Cfrmfilesearcher : Form
    {
        public Cfrmfilesearcher()
        {
            InitializeComponent();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtInput.Text !="")
                {
                    string fileName = txtInput.Text;

                    if (File.Exists(fileName))
                    {
                        GetFileInformation(fileName);

                        // we want ot read whats inside the file 
                        StreamReader readar = null;
                        try
                        {
                            using (readar = new StreamReader(fileName))
                            {
                                txtOutput.AppendText("File Contains : \n");

                                txtOutput.AppendText(readar.ReadToEnd());

                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("File Error", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, Your file does not exists!!!!!!!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid string","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void GetFileInformation(string fileName)
        {
            txtOutput.Clear();
            txtOutput.AppendText(fileName + "exists \n");

            txtOutput.AppendText("Created : " + File.GetCreationTime(fileName) + "\n");

            txtOutput.AppendText("Last accessed : " + File.GetLastAccessTime(fileName) + "\n");

            txtOutput.AppendText("Last Modified : " + File.GetLastWriteTime(fileName) + "\n");
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
