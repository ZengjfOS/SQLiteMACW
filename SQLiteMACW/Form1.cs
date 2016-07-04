using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteMACW
{
    public partial class Form1 : Form
    {
        Bitmap qrBitmap = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void addMACClick(object sender, EventArgs e)
        {
            MACSQLite.generateMacs(macB.Text, macE.Text);
            MACSQLite.printMacS();

            MACSQLite.createTable("macs");
            // MACSQLite.insertMac("macs", "00:11:22:33:44:55");
            MACSQLite.addMacs("macs");
            MACSQLite.queryMac("macs");
            // MACSQLite.deleteMac("macs", "00:11:22:33:44:55");
            // MACSQLite.updateMac("macs", 18, "11:22:33:44:55:66");

            WinCmd.cmd("dir");
            WinCmd.cmd("ipconfig");

            MACQRCode.consoleOut("00:11:22;33:44:55");
            // MACQRCode.pictureBoxOut("00:11:22;33:44:55", qrcode);
            qrBitmap = MACQRCode.bitmapOut("www.aplexos.com", qrcode);
        }

        private void printClick(object sender, EventArgs e)
        {
            if (qrBitmap == null)
            {
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printer;

            if (printDialog.ShowDialog(this) == DialogResult.OK) //到这里会出现选择打印项的窗口  
            {
                printer.Print(); //到这里会出现给文件命名的窗口，点击确定后进行打印并完成打印  
            } 
        }

        private void printerPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(qrcode.Image, 20, 20);
        }
    }
}
