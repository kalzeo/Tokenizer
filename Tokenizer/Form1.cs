using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Tokenizer
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(Bw_DoWork);
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileContents = (string)e.Argument;

            Invoke(new Action(() =>
            {
                tokenTextbox.Text = "";
                sourceTextbox.Text = "";
                sourceTextbox.Text = fileContents;
            }));

            TokenLexer lexer = new TokenLexer(fileContents);
            Token token;

            while (true)
            {
                token = lexer.NextToken();

                if (token.Type == TokenType.EOF) break;
                else if(token.Type != TokenType.Comment && token.Type != TokenType.Whitespace && token.Type != TokenType.Unknown)
                {
                    Invoke(new Action(() =>
                    {
                        tokenTextbox.Text += token.ToString();
                    }));
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            SetReadOnly(tokenTextbox, true);
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "C# files (*.cs*)|*.cs*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        if(!bw.IsBusy) bw.RunWorkerAsync(reader.ReadToEnd());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sourceTextbox.TextLength != 0)
            {
                if (!bw.IsBusy) bw.RunWorkerAsync(sourceTextbox.Text);
                else
                {
                    // do nothing - worker's busy, wait for it to complete
                }

            }
            
            else
                MessageBox.Show("Enter some text to convert into tokens", "Blank Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetReadOnly <T>(T control, bool status)
        {
            dynamic controller = Convert.ChangeType(control, typeof(T));
            controller.ReadOnly = status;
        }
    }
}
