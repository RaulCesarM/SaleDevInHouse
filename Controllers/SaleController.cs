
using Microsoft.AspNetCore.Mvc;
using SaleDevInHouse.Data.Contexts;
using SaleDevInHouse.Model;
using SaleDevInHouse.Repository;

namespace SaleDevInHouse.Controllers
{
    [ApiController]
    [Route("api/Sale")]
    public class SaleController : ControllerBase
    {
       
        private readonly SaleRepository _srepository;

        public SaleController(SaleRepository repository)
        {          
            _srepository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale([FromBody] Sale sale)
        {
            var response = await _srepository.PostSale(sale);
            if (response == null)return NoContent();      
           
            return Ok(response);
        }

        [HttpPut("{id}/sale")]
        public async Task<ActionResult<Sale>> PutSale([FromRoute] int id, [FromBody] Sale sale)
        {
            var response = await _srepository.PutSale(id, sale);
            if (response == null) return NoContent();
           
            return Ok(response);
        }


        [HttpGet]
        public async Task<ActionResult<Sale>> GetAllSales()
        {
            var response = await _srepository.GetAllSales();
            return Ok(response);
        }

        [HttpGet("{id}/sale")]
        public async Task<ActionResult<Sale>> GetByIdSale([FromRoute] int id)
        {
            var response = await _srepository.GetByIdSale(id);
            if (response == null)return NoContent();
           
            return Ok(response);
        }


        [HttpDelete]
        public async Task<ActionResult<Sale>> DeleteSale([FromRoute] int id)
        {

            var response = await _srepository.DeleteSale(id);
            if (response == null) NotFound();   

            return NoContent();
        }






    }
}