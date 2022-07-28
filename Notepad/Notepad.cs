namespace Notepad
{
    public partial class NotepadForm : Form
    {
        string FileContent;
        string FilePath;


        public NotepadForm()
        {
            InitializeComponent();                                  
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            if (FilePath == null)
            {
                using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
                {
                    SaveFileDialog.Title = "Save file";
                    SaveFileDialog.InitialDirectory = "CSIDL_MYDOCUMENTS";
                    SaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    SaveFileDialog.FilterIndex = 1;
                    SaveFileDialog.RestoreDirectory = true;

                    if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = SaveFileDialog.FileName;
                        File.WriteAllText(FilePath, TextBox.Text);
                    }
                }
            }
            else
                File.WriteAllText(FilePath, TextBox.Text);
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                OpenFileDialog.Title = "Open file";
                OpenFileDialog.InitialDirectory = "CSIDL_MYDOCUMENTS";
                OpenFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                OpenFileDialog.FilterIndex = 2;
                OpenFileDialog.RestoreDirectory = true;

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = OpenFileDialog.FileName;
                    this.TextBox.Text = File.ReadAllText(FilePath);
                }
            }
        }
    }
}