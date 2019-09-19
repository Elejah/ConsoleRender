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
            string command = "-x " + "\"" + fileName + "\"" + " -o " + "\"" + MakeNewFileName(fileName) + "\""+" -s 2";

            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files\\draw.io\\draw.io.exe";
            process.StartInfo.Arguments = command;
            process.Start();
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