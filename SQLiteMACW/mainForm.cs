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
    public partial class mainForm : Form
    {
        Bitmap qrBitmap = null;

        public mainForm()
        {
            InitializeComponent();

            initMACListView();
        }

        private void initMACListView()
        {
            macLV.GridLines = true;     //表格是否显示网格线
            macLV.FullRowSelect = true; //是否选中整行

            macLV.View = View.Details;  //设置显示方式
            macLV.Scrollable = true;    //是否自动显示滚动条
            macLV.MultiSelect = false;  //是否可以选择多行

            //添加表头（列）
            macLV.Columns.Add("ID", -2, HorizontalAlignment.Center);
            macLV.Columns.Add("MAC", -2, HorizontalAlignment.Center);

            MACSQLite.createTable("macs");
            refreshListView();
        }

        private void refreshListView()
        {

            // macLV.DataSource = null;
            macLV.Items.Clear();

            MACSQLite.queryMacs("macs");
            List<DBIdMAC> macsDB = MACSQLite.macsDB;

            //添加表格内容
            int count = MACSQLite.queryCount("macs");
            for (int i = 0; i < count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = macsDB[i].getId().ToString();
                item.SubItems.Add(macsDB[i].getMac());
                macLV.Items.Add(item);
            }
        }

        private void addMACClick(object sender, EventArgs e)
        {
            MACSQLite.generateMacs(macB.Text, macE.Text);
            MACSQLite.printMacS();

            MACSQLite.createTable("macs");
            // MACSQLite.insertMac("macs", "00:11:22:33:44:55");
            MACSQLite.addMacs("macs");
            // MACSQLite.queryMac("macs");
            // MACSQLite.deleteMac("macs", "00:11:22:33:44:55");
            // MACSQLite.updateMac("macs", 18, "11:22:33:44:55:66");

            refreshListView();
        }

        private void printClick(object sender, EventArgs e)
        {
            MACQRCode.consoleOut("00:11:22;33:44:55");
            qrBitmap = MACQRCode.bitmapOut("www.aplexos.com", qrcode);

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

        private void adbCmdClick(object sender, EventArgs e)
        {
            // WinCmd.cmd("dir");
            // WinCmd.cmd("ipconfig");

            WinCmd.cmd("adb shell mount -o remount /dev/block/mtdblock2 /system", adbcmdShow);
            WinCmd.cmd("adb shell cat /sys/bus/i2c/devices/3-0050/eeprom", adbcmdShow);
        }

    }
}
