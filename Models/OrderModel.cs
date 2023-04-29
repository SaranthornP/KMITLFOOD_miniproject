using System.ComponentModel.DataAnnotations;

namespace ProjectKMITL.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public string NameDepositor { get; set; }

        public string Cafeteria { get; set; }

        public string Restaurant { get; set; }

        public string OrderList { get; set; }

        public string OrderCount { get; set; }

        public string NameDepository { get; set; }
    }
}
