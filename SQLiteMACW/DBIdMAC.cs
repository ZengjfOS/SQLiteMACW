using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMACW
{
    class DBIdMAC
    {
        int id;
        String mac;

        public DBIdMAC(int id, string mac)
        {
            this.id = id;
            this.mac = mac;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getMac()
        {
            return mac;
        }

        public void setMac(String mac)
        {
            this.mac = mac;
        }
    }
}
