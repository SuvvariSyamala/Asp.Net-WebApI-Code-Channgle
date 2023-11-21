
using System;
using System.Collections.Generic;
using Asp.Net_WebApI_Code_Channgle.DTO;
using Asp.Net_WebApI_Code_Channgle.Entitys;
using Asp.Net_WebApI_Code_Channgle.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Asp.Net_WebApI_Code_Channgle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public OrderController(IOrderService orderService, IMapper mapper, IConfiguration configuration)
        {
            this.orderService = orderService;
            _mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet, Route("GetAllOrders")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            try
            {
                List<Order> orders = orderService.GetOrders();
                List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(orders);
                return StatusCode(200, orderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetOrdersByProductId/{productId}")]
        [Authorize]
        public IActionResult GetOrdersByProductId(int productId)
        {
            try
            {
                Order order = orderService.GetOrdersByProductId(productId);

                if (order == null)
                {
                    return NotFound($"No orders found for product with ID {productId}.");
                }

                OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);
                return StatusCode(200, orderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("AddOrder")]
        [Authorize(Roles ="User")]
        public IActionResult AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                if (orderDTO == null)
                {
                    return BadRequest("Order data is null.");
                }

                Order order = _mapper.Map<Order>(orderDTO);
                orderService.PlaceOrder(order);

                return StatusCode(201, "Order added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}