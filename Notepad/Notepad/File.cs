namespace Notepad.Notepad
{
    internal class File
    {
        static string FilePath;

        public static void Save(TextBox TextBox)
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
                        System.IO.File.WriteAllText(FilePath, TextBox.Text);
                    }
                }
            }
            else
                System.IO.File.WriteAllText(FilePath, TextBox.Text);
        }

        public static void Open(TextBox TextBox)
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
                    TextBox.Text = System.IO.File.ReadAllText(FilePath);
                }
            }
        }

        public static void New(TextBox TextBox)
        {
            TextBox.Text = null;
            FilePath = null;
        }
    }
}
