using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMACW
{
    class Eeprom
    {
        private const byte macIdType = 0x01;
        private const byte displayType = 0x0a;
        private const byte touchType = 0x10;
        private const byte serialNumberType = 0x02;

        private const int length = 256;
        public static byte[] data = new byte[length];
        private static List<DataStruct> dataList = new List<DataStruct>();

        public static void cleanDataList()
        {
            dataList.Clear();
        }

        public static void initData()
        {
            for (int i = 0; i < length; i++)
            {
                // data[i] = (byte)i;
                data[i] = 0;
            }
        }

        public static void saveData()
        {
            Bin2File.saveByteArray(data);
        }

        public static bool readDataWithCompare(String path)
        {
            byte[] fileData = Bin2File.readByteArray(path);
            for (int i = 0; i < fileData.Length; i++)
            {
                if (i > (length -1))
                    break;

                if (data[i] != fileData[i])
                    return false;
            }

            return true;
            // Bin2File.printByteArray(data);
        }

        public static void setMac(String mac){
            long macL = long.Parse(mac.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);

            DataStruct data = new DataStruct();

            data.type = DataStruct.macIdType;
            data.lenght = 0x06;
            data.data = new byte[data.lenght];

            for (int i = 0; i < 6; i++)
                data.data[i] = (byte)((macL >> ((5 - i) * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setSerialNumber(short serialNumber)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.serialNumberType;
            data.lenght = 0x02;
            data.data = new byte[data.lenght];

            for (int i = 0; i < 2; i++)
                data.data[i] = (byte)((serialNumber >> (i * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setDisplay(byte display)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.displayType;
            data.lenght = 0x01;
            data.data = new byte[data.lenght];

            data.data[data.lenght - 1] = display;

            dataList.Add(data);
        }

        public static void setTouch(byte touch)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.touchType;
            data.lenght = 0x01;
            data.data = new byte[data.lenght];

            data.data[data.lenght - 1] = touch;

            dataList.Add(data);
        }

        public static void dataListConvertToDataArray()
        {
            initData();

            //int listSize = dataList.Count();
            int index = 0;
            foreach (DataStruct ds in dataList)
            {
                data[index++] = ds.type;
                data[index++] = (byte)(ds.lenght & 0xff);
                data[index++] = (byte)((ds.lenght >> 8) & 0xff);

                for (int i = 0; i < ds.lenght; i++)
                    data[index++] = ds.data[i];
            }
        }
    }

    class DataStruct
    {
        public const byte macIdType = 0x01;
        public const byte displayType = 0x0a;
        public const byte touchType = 0x10;
        public const byte serialNumberType = 0x02;

        public byte type;
        public short lenght;
        public byte[] data;
    }
}
