public partial class SourceCodeViewer : Form
    {
        public SourceCodeViewer()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            // get list of files from selected directory
            ShowFileList();
          
        }

        private void ShowFileList()
        {
            lstFiles.Items.Clear(); // clear listbox 

            DirectoryInfo dir = new DirectoryInfo(txtDirectory.Text);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name.EndsWith(".cs"))
                    lstFiles.Items.Add(file.Name);

            }
        }

        private void ShowFileContents()
        {
            String filename = lstFiles.SelectedItem.ToString();
            filename = txtDirectory.Text + "\\" + filename;
            // MessageBox.Show( filename);

            StreamReader sr = new StreamReader(filename);
            if (chkLineNumbers.Checked)
            {
                string line = sr.ReadLine();
                int lineno = 1;
                txtContents.Text = "";
                while (line != null)
                {
                    txtContents.AppendText(String.Format("{0:####} : {1}\n", lineno, line));
                    line = sr.ReadLine();
                    lineno++;
                }

            }
            else
            {
                txtContents.Text = sr.ReadToEnd();
            }
            sr.Close();
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            ShowFileContents();
        }

        private void chkLineNumbers_CheckedChanged(object sender, EventArgs e)
        {
            ShowFileContents();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDirectory.Text = folderBrowserDialog1.SelectedPath;
                ShowFileList(); 
            }
        }
    }
