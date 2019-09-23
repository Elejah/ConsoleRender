using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
            var quality = 8;
            Collection<string> arguments = new Collection<string>()
            {
                "-x ",
                "\"" + fileName + "\"" ,
                " -o ",
                "\"" + MakeNewFileName(fileName) + "\"" ,
                " -s ",
                quality.ToString()
            };
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files\\draw.io\\draw.io.exe";
            process.StartInfo.Arguments = ConcatenateCollectionItems(arguments);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            var renderingDelay = quality * 3000;
            if (!process.WaitForExit(renderingDelay))
            {
                process.Kill();
            }
            while (!process.StandardOutput.EndOfStream)
            {
                string outputData = process.StandardOutput.ReadLine();
                Console.WriteLine(outputData);
            }
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