using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataBase
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
            else
            {
                System.Windows.Forms.MessageBox.Show("连接数据库失败", "错误");
            }
        }

        public void Insert(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();             //执行sql语句
        }

        public void Change(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();             //执行sql语句
        }

        public void Delete(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                System.Windows.Forms.MessageBox.Show("删除成功", "提示");
            else
                System.Windows.Forms.MessageBox.Show("删除失败", "提示");
        }

        public List<User> Searchlogin(string sql)
        {
            List<User> user = new List<User>();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read())
            {
                User u = new User();
                u.Name = read["Name"].ToString();
                u.Id = read["Id"].ToString();
                if (read["Flag"].ToString() == "False")
                    u.Flag = "未入园";
                else
                    u.Flag = "已入园";
                u.Idnumber = read["Idnumber"].ToString();
                u.Money = int.Parse(read["Money"].ToString());
                if(read["Role"].ToString().Equals("0"))
                {
                    u.Role = "管理员";
                }
                else
                {
                    u.Role = "游客";
                }
                if (read["Sex"].ToString() == "False")
                    u.Sex = "男";
                else
                    u.Sex = "女";
                u.Card= read["Card"].ToString();
                user.Add(u);
            }
            return user;
        }

        public Area_d SearchArea_d(string sql)
        {
            Area_d a = new Area_d();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            if (read.Read())
            {
                a.AreaName = read["Areaname"].ToString();
                a.Rage = int.Parse(read["Rage"].ToString());
                if (read["Role"].ToString().Equals("0"))
                {
                    a.Role = "管理员";
                }
                else
                {
                    a.Role = "游客";
                }
                a.OpenTime = read["OpenTime"].ToString();
            }
            return a;
        }
        public List<Area_s> SearchArea_s(string sql)
        {
            List<Area_s> A = new List<Area_s>();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read())
            {
                Area_s a = new Area_s();
                a.AreaName = read["Areaname"].ToString();
                a.Id = read["Id"].ToString();
                a.Date = read["Date"].ToString();
                A.Add(a);
            }
            return A;
        }
        public List<Order> SearchOrder(string sql)
        {
            List<Order> A = new List<Order>();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read())
            {
                Order a = new Order();
                a.Date = read["Date"].ToString();
                a.Id = read["Id"].ToString();
                a.OrderDate = read["Orderdate"].ToString();
                a.IdOfOrder=read["IdOfOrder"].ToString();
                A.Add(a);
            }
            return A;
        }
        public List<Payment> SearchPayment(string sql)
        {
            List<Payment> A = new List<Payment>();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader read = cmd.ExecuteReader();     //查询
            while (read.Read())
            {
                Payment a = new Payment();
                a.Time = read["TimeOfPay"].ToString();
                a.Id = read["Id"].ToString();
                a.Pay = int.Parse(read["Payment"].ToString());
                a.AreaName = read["AreaName"].ToString();
                a.IdOfPayment = read["IdOfPayment"].ToString();
                A.Add(a);
            }
            return A;
        }
        public void CloseDB()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("数据库无法断开", "错误");
            }
        }
    }
    public class User
    {
        public User()
        {
            Name = Id = Password = Role = Idnumber = string.Empty;
        }
        public User(User u)
        {
            Name = u.Name;
            Id = u.Id;
            Flag = u.Flag;
            Password = u.Password;
            Sex = u.Sex;
            Role = u.Role;
            Money = u.Money;
            Idnumber = u.Idnumber;
            Card = u.Card;
        }
        public string Name{ set; get; }
        public string Id { set; get; }
        public string Flag { set; get; }
        public string Password { set; get; }
        public string Sex { set; get; }
        public string Role { set; get; }
        public int Money { set; get; }
        public string Idnumber { set; get; }
        public string Card { set; get; }
    }
    class Order
    {
        public string IdOfOrder { set; get; }
        public string Id { set; get; }
        public string OrderDate { set; get; }
        public string Date { set; get; }
    }
    class Area_s
    {
        public string AreaName { set; get; }
        public string Id { set; get; }
        public string Date { set; get; }
    }
    class Area_d
    {
        public string AreaName { set; get; }
        public string Role { set; get; }
        public int Rage{ set; get; }
        public string OpenTime { set; get; }
    }
    class Payment
    {
        public string IdOfPayment { set; get; }
        public string Id { set; get; }
        public string Time { set; get; }
        public string AreaName { set; get; }
        public int Pay { set; get; }
    }
}
