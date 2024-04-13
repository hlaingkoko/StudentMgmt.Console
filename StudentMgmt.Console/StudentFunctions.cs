
using Microsoft.Data.SqlClient;
//using Microsoft.Data.SqlClient;

namespace StudentMgmt.Console
{
    //static class cna
    public static class StudentFunctions
    {
        public static void SaveStudent()
        {
            System.Console.WriteLine("Enter Student Name");
            string? name = System.Console.ReadLine();

            System.Console.WriteLine("Enter Student NRC");
            string? nrc =System.Console.ReadLine();

            System.Console.WriteLine("Enter Student Age");
            int age = Convert.ToInt32(System.Console.ReadLine());
            if (age > 45)
            {
                System.Console.WriteLine("age muust  be"); 
            }
            else
            {
                System.Console.WriteLine("...........Saving Student...........");

                //using connection string
                using (SqlConnection conn = new SqlConnection(Constants.connectionString))
                {
                    conn.Open();
                    //sql parameterization
                    //safe sql injection
                    string sqlQuery = "insert into Student(name,nrc,age) values(@name, @nrc, @age)";

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@nrc", nrc);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                System.Console.WriteLine("........Finished...........");
            }

            

        }
        public static void UpdateStudent()
        {
            System.Console.WriteLine("Enter Student Name");
            string? name = System.Console.ReadLine();

            System.Console.WriteLine("Enter Student NRC");
            string? nrc = System.Console.ReadLine();

            System.Console.WriteLine("Enter Student Age");
            int age = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("...........Saving Student...........");

            //object 
            //student instance
            Student student = new Student();
            student.name = name;
            student.nrc = nrc;
            student.age = age;
            //using connection string
            using (SqlConnection conn = new SqlConnection(Constants.connectionString))
            {
                conn.Open();
                //direct query
                //can cause sql injection
                string directSQL = $"insert into Student(name,nrc,age) values({student.name}, {student.nrc},{student.age})";
                //sql parameterization
                //safe sql injection
                string sqlQuery = "insert into Student(name,nrc,age) values(@name, @nrc, @age)";

                SqlCommand cmd = new SqlCommand(directSQL, conn);

                //cmd.Parameters.AddWithValue("@name",student.name);
                //cmd.Parameters.AddWithValue("@nrc", student.nrc);
                //cmd.Parameters.AddWithValue("@age", student.age);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            System.Console.WriteLine("........Finished...........");

        }
    }
}
