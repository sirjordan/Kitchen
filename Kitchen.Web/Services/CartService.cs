using Kitchen.Web.Data;
using Kitchen.Web.Services.Models;
using Kitchen.Web.Session;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Kitchen.Web.Services
{
    public class CartService
    {
        // TODO: Implement/move all the business logic from CartController here

        private const string CART_SESSION_KEY = "cart";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public void Add(CartItemDto item)
        {
            throw new NotImplementedException();

            var cart = Items();
            cart.Add(item);

            _httpContextAccessor.HttpContext.Session.Set(CART_SESSION_KEY, cart);
        }

        public List<CartItemDto> Items() => _httpContextAccessor.HttpContext.Session.Get<List<CartItemDto>>(CART_SESSION_KEY) ?? new List<CartItemDto>();

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Remove(CART_SESSION_KEY);
        }

        public void Purchase()
        {
            throw new NotImplementedException();
        }
    }
}
