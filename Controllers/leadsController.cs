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
    public class leadsController : ControllerBase
    {
        private readonly ILead _lead;
        public leadsController(ILead lead)
        {
            _lead = lead;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(TblLead lead)
        {
            try
            {
                var recordAffected = await _lead.Create(lead);
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
        public async Task<IActionResult> update(TblLead lead)
        {
            try
            {
                var recordAffected = await _lead.Update(lead);
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
        public async Task<IActionResult> selectall(int accountId,int status)
        {
            try
            {
                var data = await _lead.SelectAll(accountId, status);
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
        public async Task<IActionResult> selectbyid(int accountId,int leadId)
        {
            try
            {
                var data = await _lead.SelectById(accountId, leadId);
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
