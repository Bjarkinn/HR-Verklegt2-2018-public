using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class AdminAllOrderController : Controller
    {
        private AdminOrderService _adminOrderService;

        public AdminAllOrderController() {
            _adminOrderService = new AdminOrderService();
        }
        public IActionResult index()
        {
            var orderList = _adminOrderService.getAllOrder();
            return View(orderList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminOrderService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
        }

        public IActionResult orderListDisplay()
        {
            var orderList = _adminOrderService.getAllOrder();
            return View(orderList);
        }
        public IActionResult Details(int id)
        {
            var order = _adminOrderService.getOrder(id);
            return View(order);
        }
        public void orderUpdate(int oid)
        {
            //_adminOrderService.updateOrder(oid);
        }
        public void addNewOrder() 
        {
            //_adminOrderService.createOrder();
        }
    }
}
