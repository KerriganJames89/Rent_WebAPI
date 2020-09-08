using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Rent.WebAPI.Persistence.Models
{
    [Table("dbo.Bill")]
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime LastModified { get; set; }
    }
}