using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using ShopDAW.Entities.DTOs;
using ShopDAW.Repositories.OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderByPayType(string payType)
        {
            var order = await _repository.GetByPayType(payType);
            if (order == null)
                return NotFound("Order doesn't exist!");
            return Ok(new OrderDTO(order));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO dto)
        {
            Order newOrder = new Order();

            newOrder.value = dto.value;
            newOrder.payType = dto.payType;
            newOrder.date = dto.date;
            newOrder.userId = dto.userId;
            _repository.Create(newOrder);
            await _repository.SaveAsync();
            return Ok(new OrderDTO(newOrder));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _repository.GetById(id);
            if (order == null)
                return NotFound("Order doesn't exist!");
            _repository.Delete(order);
            await _repository.SaveAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateValue(int id, CreateOrderDTO dto)
        {
            var order = await _repository.GetById(id);
            if (order == null)
                return NotFound("Order doesn't exist!");
            order.value = dto.value;
            await _repository.SaveAsync();
            return Ok(new OrderDTO(order));
        }
    }
}
