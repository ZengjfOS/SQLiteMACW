using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteMACW
{
    class ADBCmd
    {
        public static bool detectDevice()
        {
            String backString = WinCmd.cmd("adb devices -l");

            string s = @"sabresd";
            Regex r = new Regex(s, RegexOptions.IgnoreCase);
            Match mB = r.Match(backString);
            if (!mB.Success)
            {
                MessageBox.Show("Please Insert Your USB Cable.");
                return false;
            }

            return true;
        }

        public static void push(String srcPath, String destPath)
        {
            WinCmd.cmd("adb push " + srcPath + " " + destPath, null);
        }

        public static void push(String srcPath, String destPath, TextBox textBox)
        {
            WinCmd.cmd("adb push " + srcPath + " " + destPath, textBox);
        }

        public static void execute(String cmd)
        {
            WinCmd.cmd("adb shell " + cmd, null);
        }

        public static void execute(String cmd, TextBox textBox)
        {
            WinCmd.cmd("adb shell " + cmd, textBox);
        }

        public static void pull(String srcPath, String destPath)
        {
            WinCmd.cmd("adb pull " + srcPath + " " + destPath, null);
        }

        public static void pull(String srcPath, String destPath, TextBox textBox)
        {
            WinCmd.cmd("adb pull " + srcPath + " " + destPath, textBox);
        }


    }
}
