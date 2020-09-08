using Rent.WebAPI.Controllers.Enterprise;
using Rent.WebAPI.Persistence;
using Rent.WebAPI.Persistence.DTO;
using Rent.WebAPI.Persistence.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rent.WebAPI.Controllers.Api
{
    [RoutePrefix("api/Bill")]
    public class BillController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await new BillEC().Get());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Ok(await new BillEC().GetById(id));
        }

        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] BillDto bill)
        {
            return Ok(await new BillEC().AddOrUpdate(bill));
        }

        [HttpGet]
        [Route("RemoveById/{id}")]
        public async Task<IHttpActionResult> RemoveById(int id)
        {
            return Ok(await new BillEC().RemoveById(id));
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IHttpActionResult> Remove([FromBody] BillDto billDto)
        {
            return Ok(new BillEC().Remove(billDto));
        }
    }
}