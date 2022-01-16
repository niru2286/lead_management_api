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
    public class sourcesController : ControllerBase
    {
        private readonly ISource _sources;
        public sourcesController(ISource sources)
        {
            _sources = sources;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(TblSource source)
        {
            try
            {
                var recordAffected = await _sources.Create(source);
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
        public async Task<IActionResult> update(TblSource source)
        {
            try
            {
                var recordAffected = await _sources.Update(source);
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
        public async Task<IActionResult> selectall(int accountId)
        {
            try
            {
                var data = await _sources.SelectAll(accountId);
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
                var data = await _sources.SelectAllByStatus(accountId, status);
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
        public async Task<IActionResult> selectbyid(int accountId,int sourceId)
        {
            try
            {
                var data = await _sources.SelectById(accountId, sourceId);
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
