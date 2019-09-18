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
            string s = "-x " + "\"" + fileName + "\"" + " -o " + "\"" + MakeNewFileName(fileName) + "\""+" -s 10";
            Process process = new Process();
            Console.WriteLine(s);
            process.StartInfo.FileName = "C:\\Program Files\\draw.io\\draw.io.exe";
            process.StartInfo.Arguments = s;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();
        }

        static string MakeNewFileName(string fileName)
        {
            var s = fileName.Replace(".xml", ".png");
            s = fileName.Replace(".drawio", ".png");

            return s;
        }
    }
}