namespace Notepad
{
    public partial class NotepadForm : Form
    {
        string FilePath;


        public NotepadForm()
        {
            InitializeComponent();                                  
        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {
            LanguageFlagDisplay();
        }

        public void LanguageFlagDisplay()
        {
            InputLanguage LanguageUsed = InputLanguage.CurrentInputLanguage;
#if DEBUG 
            string LanguageFlagIconPath = "..\\..\\..\\..\\Language Flags Debug\\" + LanguageUsed.Culture.TwoLetterISOLanguageName + ".png";
#elif RELEASE
            string LanguageFlagIconPath = "Language Flags\\" + LanguageUsed.Culture.TwoLetterISOLanguageName + ".png";
#endif
            this.LanguageFlagIcon.Image = new Bitmap(LanguageFlagIconPath);
        }

        private void NotepadForm_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            LanguageFlagDisplay();
        }

        private void LanguageFlagIcon_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// There should be a language switch here by clicking on the flag
            ///
            /// Тут повинно бути перемикання мови за допомогою натискання на прапорець
            /// 
            /// in short, I did not understand how to switch the keyboard layout
            /// maybe someday I will, but it's not certain
            /// 
            /// коротше кажучи я не зрозумів як перемикати розкладку клавіатури
            /// може колись зроблю але це не точно
            /// </summary>

            MessageBox.Show("😐", "😐");
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = null;
            this.TextBox.Text = null;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}