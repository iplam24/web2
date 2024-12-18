using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace index.dataBaseAccess
{
    public class donhangsql
    {
        connect conn = new connect();

        public void hienThidonhang(Table tbl_taikhoan)
        {
            conn.moKetNoi();
            string sql = "select * from v_dondh";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);
                for (int i = 0; i < 11; i++)
                {
                    TableCell c = new TableCell();

                    c.Text = reader[i].ToString();



                    row.Cells.Add(c);
                }
                TableCell cll = new TableCell();
                cll.Text = "<a href='suataikhoan.aspx?taikhoan=" + reader[0].ToString() + "'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn xóa tài khoản này?')) { window.location.href='xoataikhoan.aspx?taikhoan=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_taikhoan.Rows.Add(row);
                j++;
            }
        }
    }

}