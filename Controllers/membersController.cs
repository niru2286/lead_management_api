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
    public class membersController : ControllerBase
    {
        private readonly IMembers _members;
        public membersController(IMembers members)
        {
            _members = members;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(TblMember member)
        {
            try
            {
                var recordAffected = await _members.Create(member);
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
        public async Task<IActionResult> update(TblMember member)
        {
            try
            {
                var recordAffected = await _members.Update(member);
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
                var data = await _members.SelectAll(accountId);
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

        [HttpPost("selectallbystatus")]
        public async Task<IActionResult> selectallbystatus(int accountId, int status)
        {
            try
            {
                var data = await _members.SelectAllByStatus(accountId, status);
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
        public async Task<IActionResult> selectbyid(int accountId,int memberId)
        {
            try
            {
                var data = await _members.SelectById(accountId, memberId);
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
