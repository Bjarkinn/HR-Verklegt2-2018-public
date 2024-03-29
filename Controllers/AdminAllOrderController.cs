/*
        Only Admin role can use admin contoller
 */
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers {
    [Authorize(Roles = "ADMIN")]
    public class AdminAllOrderController : Controller {
        private AdminOrderService _adminOrderService;

        public AdminAllOrderController() {
            _adminOrderService = new AdminOrderService();
        }
        public IActionResult index() {
            var orderList = _adminOrderService.getAllOrder();
            return View(orderList);
        }

        [HttpPost]
        public IActionResult index(string searchString) {
            var searchResult = _adminOrderService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
        }

        public IActionResult details(int id) {
            var order = _adminOrderService.getOrder(id);
            return View(order);
        }
        public IActionResult editOrder(int id) {
			var order = _adminOrderService.getOrder(id);
            if(!order.Any()) {
                return RedirectToAction("orderNotFound");
            }
			return View(order.First());

        }
        [HttpPost]
        public ActionResult editOrder(OrderListViewModel order) {
           	if (ModelState.IsValid) {
				_adminOrderService.updateOrder(order);
				return RedirectToAction("index");
			}
			return View(order);
        }

        public IActionResult orderNotFound() {
            return View();
        }
        
        public IActionResult addOrder() {
            return View();
        }

        [HttpPost]
		public ActionResult addOrder(OrderListViewModel order) {
			if (ModelState.IsValid) {
				_adminOrderService.createOrder(order);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(order);
		}


        public IActionResult removeOrder(int id)
        {
            var order = _adminOrderService.getOrder(id);
            if(!order.Any()) {
                return RedirectToAction("OrderNotFound");
            }
			return View(order.First());

        }

        [HttpPost]
        public ActionResult removeOrder(OrderListViewModel pro){
           	if (ModelState.IsValid) {
				_adminOrderService.removeO(pro);
				return RedirectToAction("index");
			}
			return View(pro);
        }
    }
}
