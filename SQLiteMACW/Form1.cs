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

        byte[] macBArray = new byte[6];
        byte[] macEArray = new byte[6];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //translateMac();
            //swapMac();
            countBetweenMac("10:00:00:00:00:00", "10:00:00:00:00:11");
        }

        void translateMac()
        {
            String macBString = macB.Text;
            String macEString = macE.Text;

            String[] macBStrings = macBString.Split(':');
            String[] macEStrings = macEString.Split(':');

            for (int i = 0; i < 6; i++)
                macBArray[i] = byte.Parse(macBStrings[i], System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", macBArray[0], macBArray[1], macBArray[2], macBArray[3], macBArray[4], macBArray[5]);

            for (int i = 0; i < 6; i++)
                macEArray[i] = byte.Parse(macEStrings[i], System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", macEArray[0], macEArray[1], macEArray[2], macEArray[3], macEArray[4], macEArray[5]);
        }

        void swapMac(){
            int i = 0;
            int j = 0;
            byte[] tempArray = new byte[6];
            for(; i < 6; i++ )
            {
                if (macBArray[i] > macEArray[i])
                {
                    for (; j < 6; j++)
                    {
                        tempArray[j] = macBArray[j];
                        macBArray[j] = macEArray[j];
                        macEArray[j] = tempArray[j];
                    }
                    break;
                }
            }
        }

        void copyByteArray(byte[] oldArray, byte[] newArray) {
            
        }

        void calculateNextMacAddress(int[] mac, int i)
        {

            int macByte5 = ( i + mac[5] ) % 256;
            int macByte4 = ( ( i + mac[5] ) / 256  + mac[4] ) % 256;
            int macByte3 = ( ( ( ( i + mac[5] ) / 256 ) + mac[4] ) / 256  + mac[3] ) % 256;
            int macByte2 = ( ( ( ( ( i + mac[5] ) / 256 ) + mac[4] ) / 256  + mac[3] ) / 256  + mac[2] ) % 256;
            int macByte1 = ( ( ( ( ( ( i + mac[5] ) / 256 ) + mac[4] ) / 256  + mac[3] ) / 256  + mac[2] ) / 256 + mac[1] ) % 256;
            int macByte0 = ( ( ( ( ( ( ( i + mac[5] ) / 256 ) + mac[4] ) / 256  + mac[3] ) / 256  + mac[2] ) / 256 + mac[1] ) / 256 + mac[0] ) % 256;

            mac[0] = macByte0;
            mac[1] = macByte1;
            mac[2] = macByte2;
            mac[3] = macByte3;
            mac[4] = macByte4;
            mac[5] = macByte5;

            Console.WriteLine( "calculate next Mac : %02x:%02x:%02x:%02x:%02x:%02x", macByte0, macByte1, macByte2, macByte3, macByte4, macByte5 );
        }
        /** 输出两个MAC区间内的所有MAC地址 */
        public static void countBetweenMac(String macStart, String macEnd){  
            long start = turnMacToLong(macStart);  
            long end = turnMacToLong(macEnd);  
            String prefix = macStart.Substring(0,9);  
            String hex = null;  
            String suffix = null;  
            StringBuilder sb = null;  
            for(long i=start; i< end +1; i++){  
                hex = String.Format("{0:X12}", i);  
                suffix = hex.Substring(hex.Length-6);  
                sb = new StringBuilder(suffix);  
                sb.Insert(2, ":");  
                sb.Insert(5, ":");  
                Console.WriteLine(prefix + sb.ToString());  
            }  
        }
        /** 将MAC转换成数字 */
        public static long turnMacToLong(String MAC)
        {
            String hex = MAC.Replace(":", "");
            Console.WriteLine(hex);
            long longMac = long.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return longMac;
        } 

    }
}
