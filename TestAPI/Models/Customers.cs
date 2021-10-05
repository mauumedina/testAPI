
using System.Collections.Generic;
namespace TestAPI.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
    public class CustomersResult
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public List<Customers> Body { get; set; }
    }
}
