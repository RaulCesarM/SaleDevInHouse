
using Microsoft.AspNetCore.Mvc;
using SaleDevInHouse.Data.Contexts;
using SaleDevInHouse.Model;
using SaleDevInHouse.Repository;

namespace SaleDevInHouse.Controllers
{
    [ApiController]
    [Route("api/SaleCar")]
    public class SaleCarController : ControllerBase
    {
    
        private readonly SaleCarRepository _screpository;

        public SaleCarController( SaleCarRepository saleCarRepository )
        {
         
            _screpository = saleCarRepository;
        }


        [HttpPost]
        public async Task<ActionResult<SaleCar>> PostSaleCar([FromBody] SaleCar saleCar)
        {
           var response = await _screpository.PostSaleCar(saleCar);
            if(response == null) NotFound();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SaleCar>> PutSaleCar([FromBody] SaleCar saleCar,[FromRoute] int id)
        {

            var response = await _screpository.PutSaleCar(id, saleCar);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);



        }

        [HttpGet]
        public async Task<ActionResult<SaleCar>> GetAllSaleCar()
        {

            var response = await _screpository.GetAllSales();
            if(response == null){
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("{id}/salecar")]
        public async Task<ActionResult<SaleCar>> GetByIdSaleCar([FromRoute] int id)
        {

            var response = await _screpository.GetSaleCarById(id);
            if (response == null) return NoContent();           

            return Ok(response);
            
        }


        [HttpDelete]
        public async Task<ActionResult<SaleCar>> DeleteSaleCar(int id)
        {

            var response = await _screpository.DeleteSaleCar(id);
            if (response == null) NotFound();

            return NoContent();
            
        }

       
        

    
        
    }
}