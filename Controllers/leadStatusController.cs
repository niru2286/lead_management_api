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
    public class leadStatusController : ControllerBase
    {
        private readonly ILeadStatus _leadStatus;
        public leadStatusController(ILeadStatus leadStatus)
        {
            _leadStatus = leadStatus;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(TblLeadStatu status)
        {
            try
            {
                var recordAffected = await _leadStatus.Create(status);
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
        public async Task<IActionResult> update(TblLeadStatu status)
        {
            try
            {
                var recordAffected = await _leadStatus.Update(status);
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
        public async Task<IActionResult> selectall(int accountId, int status)
        {
            try
            {
                var data = await _leadStatus.SelectAll(accountId);
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
        public async Task<IActionResult> selectbyid(int accountId,int statusId)
        {
            try
            {
                var data = await _leadStatus.SelectById(accountId, statusId);
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
