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
            string s = "/k draw.io.exe -x " + "\"" + fileName + "\"" + " -o " + "\"" + MakeNewFileName(fileName) + "\"";
            System.Diagnostics.Process.Start("CMD.exe", s);
        }

        static string MakeNewFileName(string fileName)
        {
            var array = fileName.Split('\\', '.');
            var  s = array[array.Length-2];
            return s + ".png";
        }
    }
}