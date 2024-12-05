using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace index.dataBaseAccess
{
    public class userAccount
    {
        connect conn = new connect();

        public void hienThiTaiKhoan(Table tbl_taikhoan)
        {
            conn.moKetNoi();
            string sql = "select * from tbl_taikhoan";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);
                for (int i = 0; i < 3; i++)
                {
                    TableCell c = new TableCell();
                  
                    c.Text = reader[i].ToString();
                    


                    row.Cells.Add(c);
                }
                TableCell cll = new TableCell();
                cll.Text = "<a href='suasanpham.aspx?masp=" + reader[0].ToString() + "'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn xóa sản phẩm này?')) { window.location.href='xoasanpham.aspx?masp=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_taikhoan.Rows.Add(row);
                j++;
            }
        }
    }
}