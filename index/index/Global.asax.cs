using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.IO;

namespace index
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          //  KiemTraVaCaiDatSQL();
        }
        private void KiemTraVaCaiDatSQL()
        {
            try
            {
                string sqlInstallerPath = HttpContext.Current.Server.MapPath("~/App_Data/SQL2022-SSEI-Dev.exe"); // Đường dẫn tới file cài đặt SQL Server
                string scriptPath = HttpContext.Current.Server.MapPath("~/App_Data/init_database.sql"); // Đường dẫn tới script SQL
                

                // Bước 1: Kiểm tra SQL Server
                if (!KiemTraSQLServerDaCaiDat())
                {
                    CaiDatSQLServer(sqlInstallerPath); // 
                }

                // Bước 2: Tạo cơ sở dữ liệu
                TaoCoSoDuLieu(scriptPath);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý tùy ý
                File.WriteAllText(HttpContext.Current.Server.MapPath("~/App_Data/error_log.txt"), ex.Message);
            }
        }


        private bool KiemTraSQLServerDaCaiDat()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=localhost;Integrated Security=True"))
                {
                    conn.Open();
                    return true; // SQL Server đã được cài đặt
                }
            }
            catch
            {
                return false; // SQL Server chưa cài đặt
            }
        }

        private void CaiDatSQLServer(string sqlInstallerPath)
        {
            if (!File.Exists(sqlInstallerPath))
            {
                throw new Exception("File cài đặt SQL Server không tồn tại.");
            }

            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = sqlInstallerPath;

            // Loại bỏ tham số liên quan đến tên instance
            string arguments = "/QUIET /ACTION=INSTALL /FEATURES=SQL /SQLSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" /ADDCURRENTUSERASSQLADMIN";

            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit(); // Đợi cài đặt hoàn tất
        }

        

        private void TaoCoSoDuLieu(string scriptPath)
        {
            if (!File.Exists(scriptPath))
            {
                throw new Exception("File script SQL không tồn tại.");
            }

            string connectionString = "Server=localhost;Initial Catalog=webqlbandt;Integrated Security=True";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string script = File.ReadAllText(scriptPath); // Đọc file script SQL

                using (SqlCommand cmd = new SqlCommand(script, conn))
                {
                    cmd.ExecuteNonQuery(); // Thực thi script SQL
                }
            }
        }
    }

}