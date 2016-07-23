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
        private static byte[] fileData;
        private static List<DataStruct> dataList = new List<DataStruct>();
        private static List<DataStruct> fileDataList = new List<DataStruct>();

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
            fileData = Bin2File.readByteArray(path);
            int i = 0;
            for (; i < fileData.Length; i++)
            {
                if (i > (length -1))
                    break;

                if (data[i] != fileData[i])
                    return false;
            }

            if (i == data.Length)
                return true;
            else
                return false;
            // Bin2File.printByteArray(data);
        }

        public static void parseFileData()
        {
            int index = 0;
            while (true)
            {
                if (fileData[index] == 0)
                    break;

                DataStruct ds = new DataStruct();
                ds.type = fileData[index++];
                ds.length = (short)(fileData[index++] | (fileData[index++] << 8));
                ds.data = new byte[ds.length];
                for (int i = 0; i < ds.length; i++)
                    ds.data[i] = fileData[index++];

                fileDataList.Add(ds);
                // ds.toString();
            }
        }

        public static String getMac()
        {
            foreach (DataStruct ds in fileDataList)
            {
                if (ds.type == DataStruct.macIdType)
                {
                    return String.Format("{0:X02}:{1:X02}:{2:X02}:{3:X02}:{4:X02}:{5:X02}", ds.data[0], ds.data[1], ds.data[2], ds.data[3], ds.data[4], ds.data[5]);
                }
            }
            return "";
        }

        public static void setMac(String mac){
            long macL = long.Parse(mac.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);

            DataStruct data = new DataStruct();

            data.type = DataStruct.macIdType;
            data.length = 0x06;
            data.data = new byte[data.length];

            for (int i = 0; i < 6; i++)
                data.data[i] = (byte)((macL >> ((5 - i) * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setSerialNumber(short serialNumber)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.serialNumberType;
            data.length = 0x02;
            data.data = new byte[data.length];

            for (int i = 0; i < 2; i++)
                data.data[i] = (byte)((serialNumber >> (i * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setDisplay(byte display)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.displayType;
            data.length = 0x01;
            data.data = new byte[data.length];

            data.data[data.length - 1] = display;

            dataList.Add(data);
        }

        public static void setTouch(byte touch)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.touchType;
            data.length = 0x01;
            data.data = new byte[data.length];

            data.data[data.length - 1] = touch;

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
                data[index++] = (byte)(ds.length & 0xff);
                data[index++] = (byte)((ds.length >> 8) & 0xff);

                for (int i = 0; i < ds.length; i++)
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
        public short length;
        public byte[] data;

        public void toString()
        {
            Console.Write("DataStruct: {{ type = 0x{0:X02}, length = 0x{1:X02}, data = {{ ", type, length);
            int i = 0;
            for (; i < (length - 1); i++)
                Console.Write("0x{0:X02}, ", data[i]);

            Console.WriteLine("0x{0:X02} }}}}", data[i]);
        }
    }
}
