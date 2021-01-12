using System;
using Microsoft.AspNetCore.Mvc;
using Store;
using StoreWeb.Models;

namespace StoreWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IOrderRepository orderRepository;
        public CartController(IBookRepository bookRepository,
                                IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }
        public IActionResult Add(int id)
        {           
            Order order;
            Cart cart;
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            var book = bookRepository.GetById(id);
            order.AddItem(book, 1);
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            orderRepository.Update(order);
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index","Book",new { id });
        }
    }
}