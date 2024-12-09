using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace index.dataBaseAccess
{
    public class cartDatabase
    {
        connect conn = new connect();

        public void hienThiGioHang(Table tbl_giohang)
        {
            conn.moKetNoi();
            string sql = "select * from v_giohang";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);


                for (int i = 0; i <8; i++)
                {
                    TableCell c = new TableCell();
                    if (i == 3)
                    {
                        c.Text = "<img src='" + reader[i].ToString() + "'>";
                    }
                    
                    else
                    {
                        c.Text = reader[i].ToString();
                    }


                    row.Cells.Add(c);
                }
                TableCell cll = new TableCell();
                cll.Text = "<a href='suagiohang.aspx?masp=" + reader[0].ToString() + "'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn giỏ hàng này')) { window.location.href='xoagiohang.aspx?masp=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_giohang.Rows.Add(row);
                j++;
            }
        }
        public void hienThiGioHang(Repeater repeaterCart)
        {
            try
            {
                conn.moKetNoi();
                string sql = "SELECT * FROM v_giohang WHERE TaiKhoan = @TaiKhoan";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@TaiKhoan", HttpContext.Current.Session["dangnhap"]);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                repeaterCart.DataSource = dt;
                repeaterCart.DataBind();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi(); 
            }
        }

    }
}