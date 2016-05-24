public partial class DictionaryForm : Form
    {
        private SortedDictionary<string, string> words;
        private const string FILENAME = @"f:\classroom\dictionary.dat";
        public DictionaryForm()
        {
            // deseraialize 
            if (File.Exists(FILENAME))
            {
                FileStream fs = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                words = (SortedDictionary<String, string>)bf.Deserialize(fs);
                fs.Close(); 
            }
            else
                words = new SortedDictionary<string, string>();

            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (words.ContainsKey(txtWord.Text))
            {
                MessageBox.Show("Word is already existing in dictionary. Use update to update!", "Info");
                return;
            }

            words.Add(txtWord.Text, txtMeaning.Text);
            txtMeaning.Text = "";
            txtWord.Text = "";
            txtWord.Focus();

            MessageBox.Show("Word added successfully!", "Status");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SaveDictionary();
            this.Dispose();
            
        }

        private void SaveDictionary()
        {
            // take confirmation 

            FileStream fs = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, words);
            fs.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (words.ContainsKey(txtWord.Text))
            {
                txtMeaning.Text = words[txtWord.Text];
            }
            else
            {
                MessageBox.Show("Sorry! Word not found!", "Error");
                txtWord.Focus();
            }

             
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (words.Remove(txtWord.Text))
                MessageBox.Show("Word has been deleted!", "Status");
            else
                MessageBox.Show("Sorry! Word not found!", "Error");

            txtWord.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            words[txtWord.Text] = txtMeaning.Text;
            MessageBox.Show("Word has been updated!", "Status");
            txtWord.Focus();
        }

        private void DictionaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDictionary(); 
        }
    }
