using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Services;
using System.Linq;
using CustomerAPI.Models;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        

        CustomerService customerService=new CustomerService();

        //https://localhost:7153/api/customers
        [HttpGet]
        public IActionResult Get()
        {
            var result = customerService.Read();
            return Ok(result);

        }


        //https://localhost:7153/api/customers?id=1
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var result = customerService.Read(Convert.ToInt32(id));
            return Ok(result);

        }

        [HttpPost]
        public IActionResult Create(Customer customer )
        {
            customerService.Create(customer);
            return Ok();

        }

        [HttpPut]
        public IActionResult Update(Customer newCustomer)
        {

            Customer oldCustomer = (customerService.Read(Convert.ToInt32(newCustomer.Id)));
            oldCustomer.First_Name = newCustomer.First_Name;
            oldCustomer.Last_Name = newCustomer.Last_Name;
            oldCustomer.DOB = newCustomer.DOB;
            oldCustomer.Gender = newCustomer.Gender;
            Customer updatedCoustomer = oldCustomer;
            customerService.Update(updatedCoustomer);
            return Ok(updatedCoustomer);

        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            customerService.Delete(Convert.ToInt32(id));
            return Ok("Successfully Deleted");
        }
    }
}
