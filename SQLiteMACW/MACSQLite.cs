using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMACW
{
    class MACSQLite
    {
        static String macBString;
        static String macEString;
        static private long macBL;
        static private long macEL;
        static long length;
        static List<String> macsList = new List<string>();
        public static List<DBIdMAC> macsDB = new List<DBIdMAC>();

        private static void swapMac(){
            long temp = 0;

            if (macBL > macEL)
            {
                temp = macBL;
                macBL = macEL;
                macEL = temp;
            }
        }

        public static void generateMacs(String macBString, String macEString) {
            MACSQLite.macBString = macBString;
            MACSQLite.macEString = macEString;

            macBL = long.Parse(macBString.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);
            macEL = long.Parse(macEString.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);
            swapMac();

            length = (macEL - macBL) + 1;

            macsList.Clear();

            String hex = null;  
            StringBuilder sb = null;  
            for(long i= macBL; i< macEL + 1; i++)
            {  
                hex = String.Format("{0:X12}", i);  
                sb = new StringBuilder(hex);
                for (int j = 0; j < 5; j++)
                    sb.Insert((2 * (j + 1) + j), ":");
                macsList.Add(sb.ToString());
            }  
        }

        public static void printMacS()
        {
            if (length == 0)
            {
                return;
            }
            foreach (String mac in macsList) {
                Console.WriteLine(mac);
            }
        }

        private static SQLiteConnection getConnect(String name)
        {
            SQLiteConnection conn = null;

            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/" + name +  ".db";
            conn = new SQLiteConnection(dbPath);    
            conn.Open();                            

            return conn;
        }

        private static void executeSql(SQLiteConnection conn, String sql) 
        {
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = sql;
            cmdInsert.ExecuteNonQuery();

            conn.Close();
        }

        public static void createTable(String name)
        {
            SQLiteConnection conn = getConnect(name);

            String sql = "CREATE TABLE IF NOT EXISTS " + name + "(id integer PRIMARY KEY autoincrement, mac varchar(20));";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();       

            conn.Close();
        }

        public static void insertMac(String name, string mac)
        {
            SQLiteConnection conn = getConnect(name);

            String sql = "INSERT INTO macs (mac) VALUES ('" + mac + "')";

            executeSql(conn, sql);
        }

        public static void insertMac(String name, List<string> macs)
        {

            SQLiteConnection conn = getConnect(name);
            SQLiteTransaction trans =  conn.BeginTransaction();
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO macs (mac) VALUES(?)";
                SQLiteParameter macPara = cmd.CreateParameter();
                cmd.Parameters.Add(macPara);
                for (int i = 0; i < MACSQLite.length; i++)
                {
                    macPara.Value = macs[i];
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void addMacs(String name)
        {
            SQLiteConnection conn = getConnect(name);
            SQLiteTransaction trans =  conn.BeginTransaction();
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO macs (mac) VALUES(?)";
                SQLiteParameter macPara = cmd.CreateParameter();
                cmd.Parameters.Add(macPara);
                for (int i = 0; i < MACSQLite.length; i++)
                {
                    macPara.Value = MACSQLite.macsList[i];
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }

        }

        public static void queryMac(String name)
        {
            SQLiteConnection conn = getConnect(name);

            string sql = "select id, mac from macs";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmdQ.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String mac = reader.GetString(1);
                Console.WriteLine(id + ", " + mac);
            }
            conn.Close();
        }

        public static void queryMacs(String name)
        {
            SQLiteConnection conn = getConnect(name);

            string sql = "select id, mac from macs";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmdQ.ExecuteReader();

            macsDB.Clear();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                String mac = reader.GetString(1);
                macsDB.Add(new DBIdMAC(id, mac));
            }
            conn.Close();
        }

        public static int queryCount(String name)
        {
            SQLiteConnection conn = getConnect(name);

            string sql = "select count(*) from macs";
            SQLiteCommand cmdQ = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmdQ.ExecuteReader();


            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            conn.Close();

            return count;
        }

        public static void deleteMac(String name, String mac)
        {
            SQLiteConnection conn = getConnect(name);

            string sql = "delete from macs where mac = '" + mac +"'";

            executeSql(conn, sql);
        }

        public static void updateMac(String name, int id, String mac)
        {
            SQLiteConnection conn = getConnect(name);

            string sql = "update macs set mac = '" + mac + "' where id = " + id;

            executeSql(conn, sql);
        }
    }
}
