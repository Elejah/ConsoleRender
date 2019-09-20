using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
            Collection<string> arguments = new Collection<string>()
            {
                " -x ",
                "\"" + fileName + "\"" ,
                " -o ",
                "\"" + MakeNewFileName(fileName) + "\"" ,
                " -s 10 "
            };
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files\\draw.io\\draw.io.exe";
            process.StartInfo.Arguments = ConcatenateCollectionItems(arguments);
            process.Start();
            process.WaitForExit();
            //Console.WriteLine(process.ExitCode);
        }

        static string MakeNewFileName(string fileName)
        {
            var newFileName = Path.GetDirectoryName(fileName) + Path.GetFileNameWithoutExtension(fileName) + ".png";

            return newFileName;
        }

        static string ConcatenateCollectionItems(Collection<string> collection)
        {
            string concatenatedString = "";
            foreach (string item in collection)
            {
                concatenatedString += item;
            }

            return concatenatedString;
        }
    }
}