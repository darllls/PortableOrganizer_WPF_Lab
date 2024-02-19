using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Organizer.UI
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

    }

    public enum OrderStatus
    {
        [EnumMember(Value = "0")]
        New = 0,
        [EnumMember(Value = "1")]
        InProgress = 1,
        [EnumMember(Value = "2")]
        Closed = 2
    }
}
