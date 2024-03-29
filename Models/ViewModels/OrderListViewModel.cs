using System;
using System.Collections.Generic;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Models.ViewModels {
    public class OrderListViewModel {
        public int Id { get; set; }
        // Id of user who made this order.
        public string UserId { get; set; }
        // List of orderitems
        public List<int> OrderItemId { get; set; }
        // Id of orderStatus type
        public int OrderStatusId { get; set; }
        // Date when order was made.
        public DateTime Date { get; set; }
        // Genre id of order status (Finished, canceled, unfinsished...).
        public int TypeId { get; set; }
        // Id of address shipped to.
        public int AddressId { get; set; }
        public string PromoCode { get; set; }
    }
}