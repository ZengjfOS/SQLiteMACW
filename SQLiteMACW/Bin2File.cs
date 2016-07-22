using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMACW
{
    class Bin2File
    {
        public static void saveByteArray(byte[] data)
        {
            saveByteArray("eeprom.bin", data);
        }

        public static void saveByteArray(String path, byte[] data)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

            for (int i = 0; i < data.Length; i++)
                fs.WriteByte((byte)data[i]);

            fs.Close();
        }

        public static byte[] readByteArray()
        {
            return readByteArray("eeprom.bin");
        }

        public static byte[] readByteArray(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);       // 目前文件不会很大，所以int的长度已经够：了

            fs.Close();

            return data;
        }

        public static void printByteArray(byte[] data)
        {
            Console.WriteLine("0000: 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F");
            Console.WriteLine("------------------------------------------------------+");
            for (int i = 0; i < data.Length; i++)
            {
                if (i == (data.Length - 1))
                {
                    Console.WriteLine("{0:X02} |", (byte)data[i]);
                    break;
                }

                if ((i % 0x10) == 0)
                    Console.Write("{0:X04}: ", i);

                Console.Write("{0:X02} ", (byte)data[i]);

                if ((i % 0x10) == 0xf)
                    Console.WriteLine("|");
            }
            Console.WriteLine("------------------------------------------------------+");
        }
    }
}
