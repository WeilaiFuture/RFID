using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{

    class Program
    {
        SqlConnection conn = null;
        public void OpenDB()
        {
            string costring = "Data Source=.;Initial Catalog=RFID;Integrated Security=True";
            conn = new SqlConnection(costring);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            Console.WriteLine("数据库已连接");
        }

        public void Insert(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();             //执行sql语句
            if (result > 0)
                Console.WriteLine("添加成功");
            else
                Console.WriteLine("添加失败");
        }

        public void Change(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();             //执行sql语句
            if (result > 0)
                Console.WriteLine("修改成功");
            else
                Console.WriteLine("修改失败");
        }

        public void Delete(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("添加成功");
            else
                Console.WriteLine("添加失败");
        }

        public SqlDataReader Search(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            return read;
        }

        public int Searchlogin(string sql)
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read())
            {
                n += 1;
            }
            return n;
        }

        public int SearchMoney(string sql,string m)
        {
            int n = 0;
            int k = 0;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            n = int.Parse(m);
            while (read.Read())
            {
                k = read.GetInt32(5);
            }
            if (n <= k)
                return 1;
            else
                return 0;
        }

        public void CloseDB()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Console.WriteLine("数据库已断开");
        }
    }
}
