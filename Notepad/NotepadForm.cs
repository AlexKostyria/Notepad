namespace Notepad
{
    public partial class NotepadForm : Form
    {
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
            Notepad.File.New(this.TextBox);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.File.Open(this.TextBox);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad.File.Save(this.TextBox);
        }
    }
}