using EFCoreMySQL.DBContexts;  
using EFCoreMySQL.Models;  
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace EFCoreMySQL.Controllers  
{  
    [Route("api/[controller]")]  
    [ApiController]  
    public class UserController : ControllerBase  
    {  
        private MyDBContext myDbContext;  
  
        public UserController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<User> Get()  
        {  
            return (this.myDbContext.Users.ToList());  
        }  

        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int Id)
        {
            User _User = await myDbContext.Users.Select(
                    s => new User
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        UserGroupId = s.UserGroupId,
                        CreationDateTime = s.CreationDateTime,
                        LastUpdateDateTime = s.LastUpdateDateTime
                    })
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return _User;
            }
        }
    }  
}  