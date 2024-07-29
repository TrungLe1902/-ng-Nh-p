using BCrypt.Net;
using SanPhamClassLiBrary.DBconnect;
using SanPhamClassLiBrary.Model;
using System;
using System.Data.SqlClient;

namespace SanPhamClassLiBrary.Controller
{
    public class UserController
    {
        // Hàm kiểm tra xem người dùng có hợp lệ không
        public bool IsValidUser(string username, string password)
        {
            string query = "SELECT Password FROM dbo.Users WHERE Username = @Username";
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                  

                    // Lấy mật khẩu băm từ cơ sở dữ liệu
                    var storedPasswordHash = cmd.ExecuteScalar() as string;
                    conn.Close();

                    // Kiểm tra xem mật khẩu người dùng nhập có khớp với mật khẩu băm không
                    return storedPasswordHash != null && BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo lỗi phù hợp
                Console.WriteLine("Error in IsValidUser: " + ex.Message);
                return false;
            }
        }


        // Hàm đăng ký người dùng mới
        public bool RegisterUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.CreatedTime = DateTime.Now;
            user.UpdateDatetime = DateTime.Now;

            string query = "INSERT INTO dbo.Users (Username, Password, Fullname, IsAdmin, Address, CreatedTime, UpdateDatetime, CreatedUser) " +
                           "VALUES (@Username, @Password, @Fullname, @IsAdmin, @Address, @CreatedTime, @UpdateDatetime, @CreatedUser)";
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@CreatedTime", user.CreatedTime);
                    cmd.Parameters.AddWithValue("@UpdateDatetime", user.UpdateDatetime);
                    cmd.Parameters.AddWithValue("@CreatedUser", user.CreatedUser);
        
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo lỗi phù hợp
                Console.WriteLine("Error in RegisterUser: " + ex.Message);
                return false;
            }
        }
        public bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM dbo.Users WHERE Username = @Username";
            try
            {
                using (SqlConnection conn = ConnectSQLSeverDB.GetSqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
        
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo lỗi phù hợp
                Console.WriteLine("Error in IsUsernameExists: " + ex.Message);
                return false;
            }
        }
    }
    
}
