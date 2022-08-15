
using Microsoft.AspNetCore.Mvc;
using SaleDevInHouse.Model;
using SaleDevInHouse.Data.Contexts;
using SaleDevInHouse.Repository;

namespace SaleDevInHouse.Controllers
{
    [ApiController]
    [Route("api/Delivery")]
    public class DeliveryController : ControllerBase
    {
      
        private readonly DeliveryRepository _drepository;
        public DeliveryController(DeliveryRepository deliveryRepository)
        {            
            _drepository = deliveryRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(
            [FromBody] Delivery delivery)
        {
            var response = await _drepository.PostDelivery(delivery);
            if (response == null) NotFound();

            return Ok(response);
        }

        [HttpPut("{id}/delivery")]
        public async Task<ActionResult<Delivery>> PutDelivery([FromRoute] int id,[FromBody]  Delivery delivery)
        {
            var response = await _drepository.PutDelivery(id, delivery);
            if (response == null) NotFound();

            return Ok(response);
           
        }
        
        [HttpGet]
        public async Task<ActionResult<Delivery>> GetAllDelivery(){
            var response = await _drepository.GetAllDelivery();
            if(response == null) NotFound();
            return Ok(response);

        }

        [HttpGet("{id}/delivery")]
        public async Task<ActionResult<Delivery>> GetDeliveryById([FromRoute] int id)
        {
            var response = await _drepository.GetDeliveryById(id);
            if (response == null) NotFound();
            return Ok(response);
          
        }

        
        [HttpDelete]
        public async Task<ActionResult<Delivery>> DeleteDelivery([FromRoute] int id)
        {
            var response = await _drepository.DeleteDelivery(id);
            if (response == null) NotFound();
            return NoContent();
        }



    }
}