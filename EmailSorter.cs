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

namespace winformsdemo
{
    public partial class EmailSorter : Form
    {
        public EmailSorter()
        {
            InitializeComponent();
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txtSource.Text = openFileDialog1.FileName; 
        }

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txtTarget.Text = saveFileDialog1.FileName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try {
                StreamReader sr = new StreamReader(txtSource.Text);
                String content = sr.ReadToEnd();

                // create char array from string 

                String[] emails = content.Split((txtDelimeters.Text + "  \r\n").ToCharArray());
                var sortedEmails = new SortedSet<string>();
                foreach(String email in emails)
                {
#if TEST
                    Console.WriteLine("{0} {1}", email, email.Length);
#endif 
                    if (email.Length > 3 && email.Contains("@"))
                    {
#if TEST
                        Console.WriteLine("Added {0} {1}",email, email.Length);
#endif 
                        sortedEmails.Add(email);
                    }
                }

                
                // write to target file
                using (StreamWriter sw = new StreamWriter(txtTarget.Text))
                {
                    foreach (String email in sortedEmails)
                    {
                        sw.WriteLine(email);
                    }
                }
                MessageBox.Show("Process Completed Successfully!", "Status");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}


Source - Emails.txt
===================
srikanth@yahoo.com,abc@gmail.com;bbc@yahoo.com
pqr@gmail.com abc@gmail.com bbc@gmail.com
a b 
abc@msn.com
