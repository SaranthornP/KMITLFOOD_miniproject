using System.ComponentModel.DataAnnotations;

namespace ProjectKMITL.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstnameDepositor { get; set; }

        public string LastnameDepositor { get; set; }

        public string Cafeteria { get; set; }

        public string Restaurant { get; set; }

        public string OrderList { get; set; }

        public string OrderCount { get; set; }

        public string UsernameDepository { get; set; }

        public string FirstnameDepository { get; set; }

        public string LastnameDepository { get; set; }
    }
}
