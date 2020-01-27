using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userlogin.Domain
{
    public class User
    {
        private int id;
        private String lastName;
        private String firtName;
        private String address;
        private String city;

        public User() {

        }

        public User(int id, string lastName, string firtName, string address, string city)
        {
            this.id = id;
            this.lastName = lastName;
            this.firtName = firtName;
            this.address = address;
            this.city = city;
        }

        public int Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirtName { get => firtName; set => firtName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
    }
}
