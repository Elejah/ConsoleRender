using System;
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
                string news = fileName.Replace(".drawio", ".xml");
                Console.WriteLine(news);
                Console.ReadLine();
                LoadImage2();
                LoadImage1(news);
            }
        }

        static void LoadImage1(string path)
        {
            string strCmdText;
            strCmdText = "/k drawio "+path+" -o test.png";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        static void LoadImage2()
        {
            string strCmdText;
            strCmdText = "/k npm install --global draw.io - export";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
