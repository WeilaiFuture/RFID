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
        public void OpenDB(string connString)
        {
            conn = new SqlConnection(connString);
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

        public void Search(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read()) 
            {
                //示例：int number = Convert.ToInt32(read["列名1"]);          //查询列名1的数据,方法为: read(变量名)["列名"]; 该方法返回的是object类型
                //string name = read["列名2"].ToString(); 
                //Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}", number, name, revise, Email, day);
            }
    }
        public void CloseDB()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Console.WriteLine("数据库已断开");
        }

        static void Main(string[] args)
        {
            string costring = null;
            string sql = "insert into student(id,name,age,teacherID) values(5,'小王',25,105)";
            Program p = new Program();
            p.OpenDB(costring);
            p.Insert(sql);
            p.CloseDB();
            Console.ReadKey();
        }
    }
}
}
