using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMACW
{
    class WinCmd
    {
        public static void cmd(String cmd) 
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;            //是否使用操作系统shell启动
            process.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardOutput = true;      //由调用程序获取输出信息
            process.StartInfo.RedirectStandardError = false;      //重定向标准错误输出
            process.StartInfo.CreateNoWindow = true;              //不显示程序窗口
            process.Start();                                      //启动程序

            //向cmd窗口发送输入信息
            process.StandardInput.WriteLine(cmd + "&exit");

            process.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();                              //等待程序执行完退出进程
            process.Close();

            Console.WriteLine(output);
        }
    }
}
