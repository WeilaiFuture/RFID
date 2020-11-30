using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace WPFSerialAssistant
{
    class DateOrder
    {
        private int Id;
        string ordertime;
        string orderdate;
        public void Date()
        {
            //Id = text1.text;
            //ordertime = text2.text;
            //orderdate = text3.text;
            string sql = string.Format("insert into Order_table(Id,Ordertime,Orderdate) values('{0}','{1}','{2}')", Id, ordertime, orderdate);
            Program p = new Program();
            p.OpenDB();
            p.Insert(sql);
            p.CloseDB();
        }
    }
}
