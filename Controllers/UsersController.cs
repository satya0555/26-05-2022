using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
namespace API.Controllers
{         
    public class UsersController : BaseApiController
    {
        private readonly StoreContext _context;
        public UsersController(StoreContext context){
        _context=context;
        }
        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync();
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            return await _context.Users.FindAsync(id);

        }
        
    }
}









