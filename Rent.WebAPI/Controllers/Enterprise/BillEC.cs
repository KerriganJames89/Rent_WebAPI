using Rent.WebAPI.Persistence;
using Rent.WebAPI.Persistence.DTO;
using Rent.WebAPI.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Data.Entity;
using WebGrease.Css.Extensions;

namespace Rent.WebAPI.Controllers.Enterprise
{
    public class BillEC : BaseEC
    {
        public async Task<IEnumerable<BillDto>> Get()
        {
            var results = new List<BillDto>();
            using (var db = new RentContext())
            {
                try
                {
                    results = await db.Bills.Select(b => new BillDto { Id = b.Id, Name = b.Name, Amount = b.Amount }).ToListAsync();
                }
                catch (Exception e)
                {

                }
            }

            return results;
        }

        public async Task<BillDto> GetById(int id)
        {
            using (var db = new RentContext())
            {
                return await db.Bills.Where(b => b.Id == id)?.Take(1).Select(b => new BillDto { Id = b.Id, Name = b.Name, Amount = b.Amount }).FirstOrDefaultAsync();
            }

        }

        public async Task<IEnumerable<BillDto>> Search(string query)
        {

            using (var db = new RentContext())
            {
                return await db.Bills
                    .Where(b => b.Name.ToUpper().Contains(query.ToUpper()))
                    .Select(b => new BillDto { Id = b.Id, Name = b.Name, Amount = b.Amount })
                    .ToListAsync();
            }

        }


        public async Task<BillDto> AddOrUpdate(BillDto billDto)
        {
            var newBill = new Bill { Id = billDto.Id, Name = billDto.Name, Amount = billDto.Amount, LastModified = DateTime.Now };
            using (var db = new RentContext())
            {
                try
                {

                    db.Bills.AddOrUpdate(newBill);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                }
            }


            return new BillDto { Id = newBill.Id, Name = newBill.Name, Amount = newBill.Amount };
        }

        public BillDto Remove(BillDto billDto)
        {
            using (var db = new RentContext())
            {
                var result = db.Bills.Remove(new Bill { Id = billDto.Id, Name = billDto.Name, Amount = billDto.Amount });
                db.SaveChanges();
                return new BillDto { Id = result.Id, Name = result.Name, Amount = result.Amount };
            }
        }

        public async Task<Bill> RemoveById(int id)
        {
            using (var db = new RentContext())
            {
                var toRemove = db.Bills.FirstOrDefault(b => b.Id == id);
                db.Bills.Remove(toRemove);
                await db.SaveChangesAsync();
                return toRemove;
            }
        }

    }
}