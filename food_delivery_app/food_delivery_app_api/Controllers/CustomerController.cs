using Food_Delivery_App_API.Entities;
using Food_Delivery_App_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository repository)
        {
            this.customerRepository = repository;
        }
        [HttpGet]
        [Route("ViewAllRestaraunts")]
        public IActionResult GetAllRestaraunts()
        {
            try
            {
                List<Restaurant> customers = customerRepository.ViewAllRestaraunts();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetStatus/{id}")]
        public IActionResult GetStatus(long id)
        {
            try
            {
                List<Order> orders = customerRepository.OrderStatus(id);
                return Ok(orders);

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("SearchRestarauntByName/{restaurantName}")]
        public IActionResult SearchRestarauntByName(string restaurantName)
        {
            try
            {
                Restaurant restaurant = customerRepository.SearchRestarauntByName(restaurantName);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewAllRestarauntsByCity​​​​​​​​")]
        public IActionResult ViewAllRestarauntsByCity(string City)
        {
            try
            {
                List<Restaurant> restaurants = customerRepository.ViewAllRestarauntsByCity(City);
                return Ok(restaurants);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(User user)
        {
            try
            {
                customerRepository.UpdateCustomerDetails(user);
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewOrdersOfCustomer")]
        public IActionResult ViewOrdersOfCustomer(long UserId)
        {
            try
            {
                List<Order> orders = customerRepository.ViewOrdersOfCustomer(UserId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPut]
        [Route("CancelOrder")]
        public IActionResult CancelOrder(long orderId)
        {
            try
            {
                int x = customerRepository.CancelOrder(orderId);
                if (x == 1)
                {
                    return Ok("Delivered Order");
                }
                else
                {
                    return Ok("Cancelled order");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public IActionResult PlaceOrder(Order orders)
        {
            try
            {
                customerRepository.PlaceOrder(orders);
                return Ok("Order Placed and your OrderId is " + orders.OrderId);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
