using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleRender
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenFileDialog openFileDialogImage = new OpenFileDialog();
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialogImage.FileName;
                ConvertDiagram(fileName);
            }
        }

        static void ConvertDiagram(string fileName)
        {
            string s = "-x " + "\"" + fileName + "\"" + " -o " + "\"" + MakeNewFileName(fileName) + "\""+" -s 2";
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files\\draw.io\\draw.io.exe";
            process.StartInfo.Arguments = s;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();
        }

        static string MakeNewFileName(string fileName)
        {
            var newFileName = fileName.Replace(".drawio", ".png");
            if (newFileName == fileName)
            {
                newFileName = fileName.Replace(".xml", ".png");
            }
            return newFileName;
        }
    }
}