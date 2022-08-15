using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SaleDevInHouse.Data.Contexts;
using SaleDevInHouse.Model;

namespace SaleDevInHouse.Repository
{
    public class DeliveryRepository
    {


        private readonly SalesContext _context;

        public DeliveryRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Delivery> PostDelivery(Delivery delivery)
        {
            await _context.Deliveries.AddAsync(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }


        public async Task<Delivery> PutDelivery(int id, Delivery delivery)
        {

            Delivery deliveryuP = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == id);

            if (deliveryuP == null)
            {
                return null;
            }
            deliveryuP.Id = id;
            deliveryuP.AddressId = delivery.AddressId;
            deliveryuP.SaleId = delivery.SaleId;
            deliveryuP.DeliveryForecast = delivery.DeliveryForecast;


            _context.Deliveries.Update(deliveryuP);
            await _context.SaveChangesAsync();
            return deliveryuP;

        }
        public async Task<IEnumerable<Delivery>> GetAllDelivery()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetDeliveryById(int id)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Delivery> DeleteDelivery(int id)
        {
            Delivery delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null) return null;
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return delivery;

        }
    }
}
