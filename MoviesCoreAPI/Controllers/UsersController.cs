using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCoreAPI.Models;
using MoviesCoreAPI.ViewModel;

namespace MoviesCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MovieContext _context;

        public UsersController(MovieContext context)
        {
            _context = context;
        }

        // GET: /users
        [HttpGet]
        public async Task<ActionResult<List<UsersViewModel>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersVMs = new List<UsersViewModel>();

            foreach (var user in users)
            {
                usersVMs.Add(
                    new UsersViewModel()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Username = user.Username,
                        Email = user.Email,
                    }
                    );
            }

            return usersVMs;
        }

        // GET: /users/5
        [HttpGet("{password}/{email}")]
        public async Task<ActionResult<UsersViewModel>> GetUsers(string password, string email)
        {
            var users = await _context.Users.ToListAsync();

            foreach (var user in users)
            {
                if (user.Password == password && user.Email == email)
                {
                    var usersVMs = new UsersViewModel()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Username = user.Username,
                        Email = user.Email,
                    };

                    return usersVMs;
                }

            }

            return NotFound();
        }

        // PUT: /users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(UsersViewModel usersViewModel)
        {
            Users user = usersViewModel;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = user.UserID }, user);
        }

        // DELETE: /users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
