using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            // 初始化显示MAC的listview
            initMACListView();

            // 初始化显示的当前的MAC
            initCurrentMACLable();
            
            // 初始化屏、Touch、序列：号
            initSelectArgument();

            // 设置状态标签背景
            status.BackColor = Color.Green;
        }

        private void initSelectArgument()
        {
            initTouchType();
            initDisplayType();
            initSerialNumber();
        }

        private void initTouchType()
        {
            touchType.Items.Add("RES");
            touchType.Items.Add("PTC");
            touchType.SelectedIndex = 0;
        }

        private void initDisplayType()
        {
            displayType.Items.Add("7\"");
            displayType.SelectedIndex = 0;
        }

        private void initSerialNumber()
        {
            serialNo.Text = "001";
        }

        // 从数据库中获取第一行中的MAC 
        private void initCurrentMACLable()
        {
            // 这里可以从DB中获取第一行，也可通过直接获取ListView中的第一行来表示.
            String mac = MACSQLite.fetchHeadMac("macs");
            if (mac != null && mac.Length != 0)
            {
                currentMAC.Text = mac;
            }
            else
            {
                currentMAC.Text = "00:00:00:00:00:00";
            }
        }

        // 初始化ListView
        private void initMACListView()
        {
            macLV.GridLines = true;     // 表格是否显示网格线
            macLV.FullRowSelect = true; // 是否选中整行

            macLV.View = View.Details;  // 设置显示方式
            macLV.Scrollable = true;    // 是否自动显示滚动条
            macLV.MultiSelect = false;  // 是否可以选择多行

            // 添加表头（列）
            macLV.Columns.Add("ID", -2, HorizontalAlignment.Center);
            macLV.Columns.Add("MAC", -2, HorizontalAlignment.Center);

            MACSQLite.createTable("macs");
            refreshListView();
        }

        // 从数据库中获取所有的MAC，并将MAC在ListView中显示
        private void refreshListView()
        {

            // 清空ListView
            macLV.Items.Clear();

            MACSQLite.queryMacs("macs");
            List<DBIdMAC> macsDB = MACSQLite.macsDB;

            // 添加表格内容
            int count = MACSQLite.queryCount("macs");
            for (int i = 0; i < count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = macsDB[i].getId().ToString();
                item.SubItems.Add(macsDB[i].getMac());
                macLV.Items.Add(item);
            }

            // 选中listview第一行，这里会造成自动调用listview的SelectedIndexChanged事件函数；
            // 于是设置当前MAC、QRCode这事情都在macLV_SelectedIndexChanged处理了。
            // initCurrentMACLable()也就没啥用了。
            if (macLV.Items.Count > 0)
            {
                macLV.Items[0].Selected = true;
                macLV.Select();
            }
            // initCurrentMACLable();
        }

        private void addMACClick(object sender, EventArgs e)
        {
            // 校验MAC地址
            string s = @"^([0-9a-fA-F]{2})(([/\s:-][0-9a-fA-F]{2}){5})$";
            Regex r = new Regex(s, RegexOptions.IgnoreCase);
            Match mB = r.Match(macB.Text.Trim());
            Match mE = r.Match(macE.Text.Trim());
            if (!mB.Success || !mE.Success)
            {
                MessageBox.Show("Please Check Your MAC Address.");
                return;
            }

            MACSQLite.generateMacs(macB.Text, macE.Text);
            // MACSQLite.printMacs();

            MACSQLite.createTable("macs");
            MACSQLite.addMacs("macs");

            // MACSQLite.insertMac("macs", "00:11:22:33:44:55");
            // MACSQLite.queryMac("macs");
            // MACSQLite.deleteMac("macs", "00:11:22:33:44:55");
            // MACSQLite.updateMac("macs", 18, "11:22:33:44:55:66");

            refreshListView();
        }

        private void printClick(object sender, EventArgs e)
        {
            // MACQRCode.consoleOut("00:11:22;33:44:55");
            // qrBitmap = MACQRCode.bitmapOut("www.aplexos.com", qrcode);

            if (qrBitmap == null)
            {
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printer;

            if (printDialog.ShowDialog(this) == DialogResult.OK)    // 到这里会出现选择打印项的窗口  
            {
                printer.Print();                                    // 到这里会出现给文件命名的窗口，点击确定后进行打印并完成打印  
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

            EepromDataBinFile();

            // WinCmd.cmd("adb push eeprom.bin /data/local", adbcmdShow);
            // WinCmd.cmd("adb shell mount -o remount /dev/block/mtdblock2 /system", adbcmdShow);
            // WinCmd.cmd("adb shell dd if=/data/local/eeprom.bin of=/sys/bus/i2c/devices/3-0050/eeprom", adbcmdShow);
            if (!ADBCmd.detectDevice())
                return;

            ADBCmd.push("eeprom.bin", "/data/local", adbcmdShow);
            ADBCmd.execute("mount -o remount /dev/block/mtdblock2 /system", adbcmdShow);
            ADBCmd.execute("dd if=/data/local/eeprom.bin of=/sys/bus/i2c/devices/3-0050/eeprom", adbcmdShow);

            // 确认数据是否正确写入到EEPROM中
            // WinCmd.cmd("adb shell dd if=/sys/bus/i2c/devices/3-0050/eeprom of=/data/local/eeprom_bak.bin", adbcmdShow);
            // WinCmd.cmd("adb pull /data/local/eeprom_bak.bin .", adbcmdShow);

            ADBCmd.execute("dd if=/sys/bus/i2c/devices/3-0050/eeprom of=/data/local/eeprom_bak.bin", adbcmdShow);
            ADBCmd.pull("/data/local/eeprom_bak.bin", ".", adbcmdShow);
            if (Eeprom.readDataWithCompare("eeprom_bak.bin"))
            // if (Eeprom.readDataWithCompare("eeprom.bin"))
            {
                MessageBox.Show("Success.");

                Eeprom.parseFileData();
                backMAC.Text = Eeprom.getMac();

                status.Text = "Success.";
                status.BackColor = Color.Green;

                // 删除操作成功的MAC
                MACSQLite.deleteMac("macs", currentMAC.Text);
                refreshListView();
            }
            else
            {
                MessageBox.Show("False.");

                status.Text = "False.";
                status.BackColor = Color.Red;
            }
        }

        private void EepromDataBinFile()
        {
            Eeprom.cleanDataList();

            Eeprom.setMac(currentMAC.Text);

            short serialNoS;
            if (short.TryParse(serialNo.Text.Trim(), out serialNoS))
                Eeprom.setSerialNumber(serialNoS);

            Eeprom.setTouch((byte)touchType.SelectedIndex);
            Eeprom.setDisplay((byte)displayType.SelectedIndex);

            Eeprom.dataListConvertToDataArray();
            Eeprom.saveData();
        }

        private void macLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 当选择了不同的MAC的时候，对应显示当前选择的MAC和生成对应的QRCode
            if (macLV.SelectedItems.Count > 0)
            {
                currentMAC.Text = ((ListView)sender).SelectedItems[0].SubItems[1].Text;
                qrBitmap = MACQRCode.bitmapOut(currentMAC.Text, qrcode);
            }
        }

        private void deleteDB(object sender, EventArgs e)
        {
            if (MACSQLite.queryCount("macs") > 0)
            {
                // 删除MAC，并刷新listview
                MACSQLite.deleteMac("macs", currentMAC.Text);
                refreshListView();
            }
            else
            {
                currentMAC.Text = "00:00:00:00:00:00";
                qrBitmap = MACQRCode.bitmapOut("www.aplexos.com", qrcode);
            }
        }

        private void cleanAdbCmdShowClick(object sender, EventArgs e)
        {
            // 删除文本内容，并将状态标签颜色设为绿色
            adbcmdShow.Text = "";
            status.BackColor = Color.Green;
        }
    }
}
