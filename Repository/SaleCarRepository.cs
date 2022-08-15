using Microsoft.EntityFrameworkCore;
using SaleDevInHouse.Model;
using SaleDevInHouse.Data.Contexts;

namespace SaleDevInHouse.Repository
{
    public class SaleCarRepository
    {

        private readonly SalesContext _context;

        public SaleCarRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<SaleCar> PostSaleCar(SaleCar saleCar)
        {
            await _context.SalesCars.AddAsync(saleCar);
            await _context.SaveChangesAsync();
            return saleCar;

        }

        public async Task<SaleCar> PutSaleCar(int id, SaleCar saleCar)
        {
            
            SaleCar saleCarToUpdate = await _context.SalesCars.FirstOrDefaultAsync(x => x.Id == id);

            if (saleCarToUpdate == null)
            {
                return null;
            }
            saleCarToUpdate.Id = id;
            saleCarToUpdate.SaleId = saleCar.SaleId;
            saleCarToUpdate.CarId = saleCar.CarId;
            saleCarToUpdate.UnitPrice = saleCar.UnitPrice;
            saleCarToUpdate.Amount = saleCar.Amount;

            _context.SalesCars.Update(saleCarToUpdate);
            await _context.SaveChangesAsync();
            return saleCarToUpdate;

        }
        public async Task<IEnumerable<SaleCar>> GetAllSales()
        {
            return await _context.SalesCars.ToListAsync();
        }



        public async Task<SaleCar> GetSaleCarById(int id)
        {
            return await _context.SalesCars.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<SaleCar> DeleteSaleCar(int id)
        {
            SaleCar salesCars = await _context.SalesCars.FindAsync(id);
            if (salesCars == null) return null;
                    
                _context.Remove(id);
                await _context.SaveChangesAsync();
                return salesCars;

        }



    }
}
