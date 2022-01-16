using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pms_api.Model;
using pms_api.Abstract;

namespace pms_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class notesController : ControllerBase
    {
        private readonly INotes _notes;
        public notesController(INotes notes)
        {
            _notes = notes;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(TblNote note)
        {
            try
            {
                var recordAffected = await _notes.Create(note);
                if (recordAffected > 0)
                {
                    return Ok(
                        new
                        {
                            Status = 1,
                            Message = "Saved!"
                        });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 2,
                        Message = "Not saved!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 2,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> update(TblNote note)
        {
            try
            {
                var recordAffected = await _notes.Update(note);
                if (recordAffected > 0)
                {
                    return Ok(
                        new
                        {
                            Status = 1,
                            Message = "Saved!"
                        });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 2,
                        Message = "Not saved!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 2,
                    Message = ex.Message
                });
            }
        }
        [HttpPost("selectall")]
        public async Task<IActionResult> selectall(int accountId,int leadId, int status)
        {
            try
            {
                var data = await _notes.SelectAll(accountId,leadId, status);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 2,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("selectbyid")]
        public async Task<IActionResult> selectbyid(int accountId,int noteId)
        {
            try
            {
                var data = await _notes.SelectById(accountId, noteId);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = 2,
                    Message = ex.Message
                });
            }
        }
    }
}
