using Microsoft.EntityFrameworkCore;
using SaleDevInHouse.Model;
using SaleDevInHouse.Data.Contexts;

namespace SaleDevInHouse.Repository
{
    public class SaleRepository
    {
        private readonly SalesContext _context;
        public SaleRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Sale> PostSale(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;

        }

        public async Task<Sale> PutSale(int id, Sale sale)
        {

            Sale saleToUpdate = await _context.Sales.FirstOrDefaultAsync(x => x.Id == id);
            if (saleToUpdate == null)
            {
                return null;
            }
            saleToUpdate.Id = id;
            saleToUpdate.SaleDate = DateTime.Now;
            saleToUpdate.SallerId = sale.BuyerId;
            saleToUpdate.BuyerId = sale.BuyerId;
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
            return saleToUpdate;

        }


        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _context.Sales.ToListAsync();
        }

       
        public async Task<Sale> GetByIdSale(int id)
        {
            return await _context.Sales.FirstOrDefaultAsync(x => x.Id == id);
        }

       
        public async Task<Sale> DeleteSale(int id)
        {
            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null) return null;
            
                _context.Remove(id);
                await _context.SaveChangesAsync();
                return sale;

          
        }
       


    }
}
