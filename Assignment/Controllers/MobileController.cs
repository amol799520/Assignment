using Assignment.InterFaces;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService _Mobile;

        public MobileController(IMobileService mobile)
        {
            _Mobile = mobile;
        }

       [HttpGet]
        public ActionResult<IEnumerable<Mobile>> GetAllMobile()
        {
            try
            {
                var mobiles = _Mobile.GetAllMobile();
                return Ok(mobiles);
            }
            catch (Exception)
            {
                return NotFound();
            }   
        }
        
        [HttpGet ("{id}")]
        public ActionResult<IEnumerable<Mobile>> GetMobileById(int id)
        {
            try
            {
                var mobile = _Mobile.GetMobileById(id);
                if (mobile == null)
                {
                    return NotFound();
                }
                return Ok(mobile);
            }
            catch (Exception)
            {
                return NotFound();
            }              
        }
      
        [HttpPost]
        public ActionResult AddMobile([FromBody] Mobile mobile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = _Mobile.AddMobile(mobile);
                    return CreatedAtAction("Get", new { id = mobile.Id }, item);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Mobile> UpdateEmployee(int id, [FromBody] Mobile mobile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existingItem = _Mobile.GetMobileById(id);
                if (existingItem == null)
                {
                    return NotFound();
                }
                _Mobile.UpdateMobile(id, mobile);
                return mobile;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
   
        [HttpDelete("{id}")]
        public ActionResult DeleteMobile(int id)
        {
            try
            {
                var existingItem = _Mobile.GetMobileById(id);
                if (existingItem == null)
                {
                    return NotFound();
                }
                _Mobile.DeleteMobile(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
