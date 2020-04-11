using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;


namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            //string cns = @"Provider = Microsoft.JetOLEDB.4.0;Data Source = D:\StudentsTable.mdb";
            string cns = @"Provider = 'Microsoft.ACE.OLEDB.12.0';Data Source = 'D:\db\StudentsTable.mdb'";

            Console.Write("Enter Student Name : ");
            string sname = Console.ReadLine();

            using (OleDbConnection dbCon = new OleDbConnection())
            {
                
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into StudentList([StudentName]) values('"+sname+"')";

                dbCon.ConnectionString = cns;
                cmd.Connection = dbCon;

                dbCon.Open();
                cmd.ExecuteNonQuery();
                dbCon.Close();

            }
            using (OleDbConnection db = new OleDbConnection())
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from StudentList";

                cmd.Connection = db;
                db.Open();
                OleDbDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Console.WriteLine(data.GetInt32(0)+" | "+data.GetString(1));
                }
                db.Close();

            }
        }
    }
}
