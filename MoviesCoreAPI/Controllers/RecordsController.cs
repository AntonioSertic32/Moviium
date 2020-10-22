using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoviesCoreAPI.Models;
using MoviesCoreAPI.ViewModel;

namespace MoviesCoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private MovieContext _context { get; set; }
        public RecordsController(MovieContext context)
        {
            _context = context;
        }

        // GET: /records
        [HttpGet]
        public async Task<ActionResult<List<RecordsViewModel>>> GetAllRecords()
        {
            var records = await _context.Records.ToListAsync();
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
        public async Task<ActionResult<Records>> PostRecords(int rate, int userid, int movieid)
        {
            Records record = new Records()
            {
                Rate = rate,
                MovieId = movieid,
                UserId = userid
            };

            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecordByID", new { id = movieid }, record);
        }

        //PUT /records/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, [FromBody] Records record)
        {
            if (id != record.RecordID)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(GetRecordByID(id) != null)
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
