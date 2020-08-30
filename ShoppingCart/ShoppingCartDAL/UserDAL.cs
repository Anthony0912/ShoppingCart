using ShoppingCartEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDB;

namespace ShoppingCartDAL
{
    public class UserDAL
    {
        public EUser getAllUser(EUser eu)
        {
            EUser t = new EUser();
            using (SqlConnection conn = new SqlConnection(ConnectionDB.conString))
            {
                conn.Open();
                string sql = "SELECT id, name, lastname, birthday, country, state," +
                    " place, postal, direction_1, direction_2, email FROM users WHERE email = @email;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", eu.Email);
                SqlDataReader reader = cmd.ExecuteReader();
                t = getUser(reader);
                if (!BCrypt.Net.BCrypt.Verify(eu.Password, t.Password))
                {
                    throw new Exception("El correo o contraseña son incorrectos.");
                }
            }
            return t;
        }

        public void SignUp(EUser eu)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionDB.conString))
            {
                conn.Open();
                const int WorkFactor = 14;
                string Password = BCrypt.Net.BCrypt.HashPassword(eu.Password, WorkFactor);
                string sql = "INSERT INTO users (name, lastname, email, password) VALUES " +
                    "(@name, @lastname, @email, @pass)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", eu.Name);
                cmd.Parameters.AddWithValue("@lastname", eu.Lastname);
                cmd.Parameters.AddWithValue("@email", eu.Email);
                cmd.Parameters.AddWithValue("@pass", Password);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(EUser eu)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionDB.conString))
            {
                conn.Open();
                string sql = "INSERT INTO users (" +
                    "name, lastname, birthday, country, state, place, postal, direction_1, direction_2)" +
                    " VALUES(@name, @lastname, @birthday, @country, @state, @place, @postal, @direct_1, @direct_2)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", eu.Name);
                cmd.Parameters.AddWithValue("@lastname", eu.Lastname);
                cmd.Parameters.AddWithValue("@birthday", new DateTime(1996, 12, 31, 00, 00, 00));
                cmd.Parameters.AddWithValue("@country", eu.Country);
                cmd.Parameters.AddWithValue("@state", eu.State);
                cmd.Parameters.AddWithValue("@place", eu.Place);
                cmd.Parameters.AddWithValue("@postal", eu.Postal);
                cmd.Parameters.AddWithValue("@direct_1", eu.Direction_1);
                cmd.Parameters.AddWithValue("@direct_2", eu.Direction_2);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmail(EUser eu)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionDB.conString))
            {
                conn.Open();
            }
        }
        public void UpdatePassword(EUser eu)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionDB.conString))
            {
                conn.Open();
            }
        }

        internal EUser getUser(SqlDataReader reader)
        {
            EUser eu = new EUser();
            if (reader.Read())
            {
                eu.Id = reader.GetInt32(0);
                eu.Name = reader.GetString(1);
                eu.Lastname = reader.GetString(2);
                eu.Birthday = reader.GetDateTime(3);
                eu.Country = reader.GetString(4);
                eu.State = reader.GetString(5);
                eu.Place = reader.GetString(6);
                eu.Postal = reader.GetInt32(7);
                eu.Direction_1 = reader.GetString(8);
                eu.Direction_2 = reader.GetString(9);
                eu.Email = reader.GetString(10);
            }
            return eu;
        }
    }
}
