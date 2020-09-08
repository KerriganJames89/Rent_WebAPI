using Rent.WebAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.WebAPI.Persistence
{
    public static class DbMock
    {
        public static List<Bill> Bills = new List<Bill> { 
            new Bill{Id = 1, Name = "Kelley", Amount = 250},
            new Bill{Id = 2, Name = "Bob", Amount = 580},
            new Bill{Id = 3, Name = "Tim", Amount = 345}
        };
    }
}