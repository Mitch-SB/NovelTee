using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _context = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetCartTotal();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetCartItems();

            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = shoppingCartItem.Quantity,
                    Price = shoppingCartItem.Product.Price,
                    ProductId = shoppingCartItem.Product.Id,
                    VariantId = shoppingCartItem.TeeVariant.Id,
                    OrderId = order.OrderId
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }
    }
}