using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LaunchClipboard
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var clipString = string.Empty;

            try
            {
                //Get the string content of the clipboard if it is text
                if (!Clipboard.ContainsText())
                    throw new ArgumentException("The content of the clipboard is not text.");
                else
                    clipString = Clipboard.GetText().Trim();

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

                //Its is not a valid path
                var errorMessage = "The file path does not appear to be valid:";
                var errorClip = $"\"{clipString}\"";

                //Return the messagebox
                MessageBox.Show(
                    $"{errorMessage}{Environment.NewLine}{Environment.NewLine}{errorClip}"
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
