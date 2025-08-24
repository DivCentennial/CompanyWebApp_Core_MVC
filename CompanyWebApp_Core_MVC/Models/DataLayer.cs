using System.Data.SqlClient;

namespace CompanyWebApp_Core_MVC.Models


{
    public class DataLayer
    {
        private string connectionString = "Data Source=DIVYANSHOO\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True;";

        public List<Department> GetDepartments()
        {
            List<Department> list = new();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Department_Details", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Department
                    {
                        Department_ID = Convert.ToInt32(rdr["Department_ID"]),
                        Department_Name = rdr["Department_Name"].ToString()
                    });
                }
            }
            return list;
        }

        public Department GetDepartment(int id)
        {
            Department dept = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Department_Details WHERE Department_ID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    dept = new Department
                    {
                        Department_ID = Convert.ToInt32(rdr["Department_ID"]),
                        Department_Name = rdr["Department_Name"].ToString()
                    };
                }
            }
            return dept;
        }

        public void CreateDepartment(Department dept)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Department_Details (Department_ID, Department_Name) VALUES (@id, @name)", con);
                cmd.Parameters.AddWithValue("@id", dept.Department_ID);
                cmd.Parameters.AddWithValue("@name", dept.Department_Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(Department dept)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Department_Details SET Department_Name=@name WHERE Department_ID=@id", con);
                cmd.Parameters.AddWithValue("@id", dept.Department_ID);
                cmd.Parameters.AddWithValue("@name", dept.Department_Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Department_Details WHERE Department_ID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

