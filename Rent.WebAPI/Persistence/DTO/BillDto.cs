using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rent.WebAPI.Persistence.DTO
{
    public class BillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}