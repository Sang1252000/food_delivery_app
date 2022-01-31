using Food_Delivery_App_API.Entities;
using Food_Delivery_App_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //need to implement in UI
    //[Authorize(Roles = "Owner")]
    public class RestaurantOwnerController : ControllerBase
    {
        private readonly IRestaurantOwnerRepository restaurantOwnerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public RestaurantOwnerController(IRestaurantOwnerRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            this.restaurantOwnerRepository = repository;
            this._hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Route("ViewDeliveryAgentDetails")]
        public IActionResult ViewDeliveryAgentDetails(long restaurantId)
        {
            try
            {
                DeliveryAgent deliveryAgents = restaurantOwnerRepository.ViewDeliveryAgentDetails(restaurantId);
                return Ok(deliveryAgents);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewMenu")]
        public IActionResult ViewMenu(long restaurantId)
        {
            try
            {
                List<Item> items = restaurantOwnerRepository.ViewMenu(restaurantId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewOrderDetails")]
        public IActionResult ViewOrderDetails(long restaurantId)
        {
            try
            {
                List<Order> orders = restaurantOwnerRepository.ViewOrderDetails(restaurantId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewRestaurantDetails")]
        public IActionResult ViewRestaurantDetails(long restaurantId)
        {
            try
            {
                Restaurant restaurant = restaurantOwnerRepository.ViewRestaurantDetails(restaurantId);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddAgentDetails")]
        public IActionResult AddAgentDetails(DeliveryAgent deliveryAgent)
        {
            try
            {
                restaurantOwnerRepository.AddAgentDetails(deliveryAgent);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateAgentDetails")]
        public IActionResult UpdateAgentDetails(DeliveryAgent deliveryAgent)
        {
            try
            {
                restaurantOwnerRepository.UpdateAgentDetails(deliveryAgent);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateRestaurant")]
        public IActionResult PutUpdateRestaurant(Restaurant restaurant)
        {
            try
            {
                
                restaurantOwnerRepository.UpdateRestaurant(restaurant);
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        //[HttpPut]
        [HttpPost]
        [Route("UpdateItem")]
        public IActionResult UpdateItem(Item item)
        {
            try
            {
                var itemImg = item.ItemImg.Substring(0, 14);
                if (itemImg != "/iDigital8--Online-Food-Delivery-Application/Food_Delivery_App/Food_Delivery_App_API/ImageStorage/")
                {
                    item.ItemImg = GetImg(item.ItemImg);
                }
                restaurantOwnerRepository.UpdateItem(item);
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateOrderStatus")]
        public void UpdateOrderStatus(Order order)
        {
            restaurantOwnerRepository.UpdateOrderStatus(order);
        }
        [HttpPost]
        [Route("AddItem")]
        public IActionResult AddItem(Item item)
        {
            try
            {
                item.ItemImg = GetImg(item.ItemImg);
                restaurantOwnerRepository.AddItem(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        string Filename;
        private string GetImg(string img)
        {
            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            img = regex.Replace(img, string.Empty);
            byte[] Files = Convert.FromBase64String(img);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + "/iDigital8--Online-Food-Delivery-Application/Food_Delivery_App/Food_Delivery_App_API/ImageStorage";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            var data = img.Substring(0, 5);
            switch (data.ToUpper())
            {
                case "IVBOR":
                    Filename = Guid.NewGuid().ToString() + ".png";
                    break;
                case "/9J/4":
                    Filename = Guid.NewGuid().ToString() + ".jpg";
                    break;
            }
            string imgPath = Path.Combine(path, Filename);
            System.IO.File.WriteAllBytes(imgPath, Files);
            string Images = "/iDigital8--Online-Food-Delivery-Application/Food_Delivery_App/Food_Delivery_App_API/ImageStorage/" + Filename;
            return Images;
        }
        // C:\Users\admin\Desktop\Food Delivery App\iDigital8--Online-Food-Delivery-Application\Food_Delivery_App\Food_Delivery_App_API\ImageStorage\
        [HttpDelete]
        [Route("DeleteItem")]
        public IActionResult DeleteItem(long itemId)
        {
            try
            {
                restaurantOwnerRepository.DeleteItem(itemId);
                return Ok("Item Deleted Successfully");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddRestaurant")]
        public IActionResult AddRestaurant(Restaurant restaurant)
        {
            try
            {
                restaurantOwnerRepository.AddRestaurant(restaurant);
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetItemById")]
        public IActionResult GetItemById(long itemId)
        {
            try
            {
                Item item = restaurantOwnerRepository.GetItemById(itemId);
                return Ok(item);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAgentById")]
        public IActionResult GetAgentById(long agentId)
        {
            try
            {
                DeliveryAgent deliveryAgent = restaurantOwnerRepository.GetAgentById(agentId);
                return Ok(deliveryAgent);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetOrderById")]
        public IActionResult GetOrderById(long orderId)
        {
            try
            {
                Order order = restaurantOwnerRepository.GetOrderById(orderId);
                return Ok(order);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
