using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userlogin.Domain;

namespace userlogin.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { 
        private static List<User> userList = new List<User>();
        private static int id = 0;

        [HttpGet("[action]")]
        public ActionResult Users()
        {
            Debug.WriteLine(GetData());
            Open();
            userList.Add(new User(id++,"sri","d","livonia","livonia"));
            return Ok(userList);
        }

        [HttpPost("[action]")]
        public ActionResult Users(User user)
        {   
           userList.Add(user);
           Debug.WriteLine(userList.Capacity);
           return Ok(userList);
        }

        private String GetData() {

            using (HttpClient client = new HttpClient())
            {

                var response = client.GetAsync("http://google.com").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    return responseString;
                }
               
            }

            return null;

        }


        private void Open() {
            SqlConnection conn = new SqlConnection();
            String ConnectionString =
                 "Data Source=(localdb)\\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;" +
                 "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "SELECT * FROM dbo.UserTable";
             List<User> persons = new List<User>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.UserTable", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            User p = new User();
                            // To avoid unexpected bugs access columns by name.
                            p.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                            p.FirtName = reader.GetString(reader.GetOrdinal("FirstName"));
                           
                            p.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                            Debug.WriteLine(reader.GetString(reader.GetOrdinal("LastName")));
                            persons.Add(p);
                        }
                    }
                }
            }

           
        }




    }
}