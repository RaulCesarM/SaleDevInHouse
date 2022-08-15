using System.ComponentModel.DataAnnotations;

namespace SaleDevInHouse.Model {
    public class Sale { 
       
        public int Id { get; internal set; }
        public int BuyerId { get; set; }
        public int SallerId { get; set; }
        public DateTime SaleDate { get; set; }
        public Sale() {
        }
        public Sale(int buyerId, int sallerId, DateTime saleDate) {
            this.BuyerId = buyerId;
            this.SallerId = sallerId;
            this.SaleDate = saleDate;
        }
    }
}
