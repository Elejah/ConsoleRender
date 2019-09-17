using System;
using System.Windows.Forms;

namespace ConsoleRender
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("Path", "C:\\Program Files\\draw.io", EnvironmentVariableTarget.Machine);
            OpenFileDialog openFileDialogImage = new OpenFileDialog();
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialogImage.FileName;
                ConvertDiagram(fileName);
            }
        }

        static void ConvertDiagram(string fileName)
        {
            string name = MakeNewFileName(fileName);
            string s = "/k draw.io.exe -x " + "\"" + fileName + "\"" + " -o " + "\"" + fileName + "\"";
            System.Diagnostics.Process.Start("CMD.exe", s);
        }

        static string MakeNewFileName(string fileName)
        {
            return fileName.Split('\\', '.')[1] + ".png";
        }
    }
}