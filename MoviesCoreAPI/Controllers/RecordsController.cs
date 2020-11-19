using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MoviesCoreAPI.Models;
using MoviesCoreAPI.ViewModel;

namespace MoviesCoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private MovieContext _context { get; set; }
        private readonly IConfiguration _configuration;
        public RecordsController(MovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: /records
        [HttpGet]
        public async Task<ActionResult<List<RecordsViewModel>>> GetAllRecords()
        {
            var records = await _context.Records.ToListAsync();
            var recordsVMs = new List<RecordsViewModel>();

            foreach (var record in records)
            {
                record.Movie = _context.Movies.Where(m => m.MovieID == record.MovieId).FirstOrDefault();
                recordsVMs.Add(
                    record
                );
            }

            return recordsVMs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecordsViewModel>> GetRecordByID(int id)
        {
            RecordsViewModel recordViewModel = await _context.Records.Where(r => r.RecordID == id).FirstOrDefaultAsync();
            return recordViewModel;
        }

        // GET /records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RecordsViewModel>>> GetRecordsByUserId(int id)
        {

            var records = await _context.Records.Where(r=>r.UserId == id).ToListAsync();
            var recordsVMs = new List<RecordsViewModel>();

            foreach (var record in records)
            {
                recordsVMs.Add(
                    new RecordsViewModel()
                    {
                        RecordID = record.RecordID,
                        Rate = record.Rate,
                        Movie = _context.Movies.Where(m => m.MovieID == record.MovieId).FirstOrDefault(),
                        User = record.User
                    }
                );
            }

            return recordsVMs;
        }

        // POST /records
        [HttpPost]
        public async Task<HttpResponseMessage> PostRecords([FromBody]RecordPostDTO recordPostDTO)
        {
            string sqlCustomerInsert = $"INSERT INTO Records (MovieId,UserId,Rate) VALUES ({recordPostDTO.MovieId},{recordPostDTO.UserId},{recordPostDTO.Rate});";
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var affectedRows = await connection.ExecuteAsync(sqlCustomerInsert);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Radi misko!", System.Text.Encoding.UTF8, "application/json") };
        }

        //PUT /records/5
        [HttpPut]
        public async Task<IActionResult> PutRecord([FromBody] Records record)
        {
            //_context.Entry(record).State = EntityState.Modified;

            _context.Records.Attach(record);
            _context.Entry(record).Property(x => x.Rate).IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(GetRecordByID(record.RecordID) != null)
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

        // DELETE /records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Records>> DeleteRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return record;
        }
    }
}
