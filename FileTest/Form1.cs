using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string fileName = inputTextBox.Text;

                IFileSystemRepository repository =
                    new FileSystemRepository(fileName);

                string info = repository.GetFileInformation();

                outputTextBox.Clear();

                if (info != null)
                {
                    outputTextBox.AppendText(info);

                    if (repository.FileExists())
                    {
                        string content = repository.ReadFile();

                        if (content != null)
                        {
                            outputTextBox.AppendText(content);
                        }
                        else
                        {
                            MessageBox.Show("Error al leer el archivo",
                            "Error de archivo");
                        }
                    }
                    else
                    {
                        string[] directoryList = repository.GetDirectories();

                        outputTextBox.AppendText("Contenido del directorio:\n");

                        foreach (string directory in directoryList)
                        {
                            outputTextBox.AppendText($"{directory}\n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"{inputTextBox.Text} no existe",
                    "Error de archivo");
                }
            }
        }
    }
}
