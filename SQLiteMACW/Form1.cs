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
            MACQRCode.pictureBoxOut("www.aplexos.com", qrcode);
        } 
    }
}
