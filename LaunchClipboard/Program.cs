using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LaunchClipboard
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var clipString = string.Empty;

            try
            {
                //Get the string content of the clipboard if it is text
                if (!Clipboard.ContainsText())
                    throw new ArgumentException("The content of the clipboard is not text.");

                clipString = Clipboard.GetText().Trim();

                //Make sure it is not calling itself
                if (clipString.EndsWith(AppDomain.CurrentDomain.FriendlyName))
                    throw new ArgumentException($"{AppDomain.CurrentDomain.FriendlyName} seems to be attempting to launch itself!");

                //Create the process for launch the file
                var proc = new Process
                {
                    StartInfo =
                    {
                        FileName = clipString,
                        UseShellExecute = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                //Check the length
                if (clipString.Length > 100)
                    clipString = $"{clipString.Substring(0, 100)} ...";

                //Its is not a valid path so return the message box
                MessageBox.Show(
                    $"The file path does not appear to be valid:{Environment.NewLine}{Environment.NewLine}\"{clipString}\""
                    , "Launch Clipboard"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                //All others
                MessageBox.Show(ex.Message
                    , "Launch Clipboard"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
            }

        }
    }
}
