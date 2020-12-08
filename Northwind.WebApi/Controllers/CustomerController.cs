using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/Customer")]
    public class CustomerController:Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.customer.GetById(id));
        }
        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows) {
            return Ok(_unitOfWork.customer.CustomerPagedList(page, rows));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer) {
            if (!ModelState.IsValid) return BadRequest(); {
                return Ok(_unitOfWork.customer.Insert(customer));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Customer customer) {
            if (ModelState.IsValid&& _unitOfWork.customer.Update(customer))
            {
                return Ok(new { Message = "The customer is updated" });
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody]Customer customer) {
            if (customer.Id > 0) {
                return Ok(_unitOfWork.customer.Delete(customer));
            }
           return BadRequest();
        }
     }

        
 }

