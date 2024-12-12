using AutoMapper;
using FoodReceipeManagement.Controllers.Models;
using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.Entities.Models;
using FoodReceipeManagement.Core.Manager;
using Microsoft.AspNetCore.Mvc;


namespace FoodReceipeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodReceipeController : ControllerBase
    {
        private readonly IReceipeManager _receipeManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public FoodReceipeController(IReceipeManager receipeManager, IMapper mapper, ILoggerManager logger)
        {
            _receipeManager = receipeManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceipes()
        {
            try
            {
                var receipes = await _receipeManager.GetAllReceipesAsync();
                var receipesResult = _mapper.Map<IEnumerable<ReceipeDto>>(receipes);
                return Ok(receipesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllReceipes Action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceipeById(int id)
        {
            try
            {
                var result = await _receipeManager.GetReceipeByIdAsync(id);

                if (result.IsFailed)
                {
                    return NotFound();
                }
                else
                {
                    var receipeResult = _mapper.Map<ReceipeDto>(result.Value);
                    return Ok(receipeResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReceipeById Action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReceipe([FromBody] ReceipeForAddDto receipeForAddDto)
        {
            try
            {
                if(receipeForAddDto is null)
                {
                    _logger.LogError("Receipe object sent is null.");
                    return BadRequest("Receipe object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Receipe object sent.");
                    return BadRequest("Invalid model object");
                }
                var receipeEntity = _mapper.Map<Receipe>(receipeForAddDto);

                await _receipeManager.AddReceipe(receipeEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddReceipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateReceipe(int id, [FromBody] ReceipeForUpdateDto receipeForUpdateDto)
        {
            try
            {
                if (receipeForUpdateDto is null)
                {
                    _logger.LogError("Receipe object sent is null.");
                    return BadRequest("Receipe object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Receipe object sent.");
                    return BadRequest("Invalid model object");
                }
                var result = await _receipeManager.GetReceipeByIdAsync(id);
                if(result.IsFailed)
                {
                    return NotFound();
                }
                _mapper.Map(receipeForUpdateDto, result.Value);

                await _receipeManager.UpdateReceipe(result.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReceipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReceipe(int id)
        {
            try
            {
                var result = await _receipeManager.DeleteReceipe(id);
                if (result.IsFailed)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteReceipe action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        [Route("BackFillData")]
        public async Task BackFillData()
        {
            await _receipeManager.BackFillData();
        }

    }
}
