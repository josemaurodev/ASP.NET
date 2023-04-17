using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsReviewApp.Dto;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;

        public ToolController(IToolRepository toolRepository, IMapper mapper)
        {
            this._toolRepository = toolRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tool>))]
        public IActionResult GetTools()
        {
            var tools = _mapper.Map<List<ToolDto>>(_toolRepository.GetTools());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tools);
        }

        [HttpGet("{toolId}")]
        [ProducesResponseType(200, Type = typeof(Tool))]
        [ProducesResponseType(400)]
        public IActionResult GetTool(int toolId)
        {
            if(!_toolRepository.ToolExists(toolId))
                return NotFound();

            var tool = _mapper.Map<ToolDto>(_toolRepository.GetTool(toolId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tool);
        }

        [HttpGet("{toolId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetToolRating(int toolId)
        {
            if(!_toolRepository.ToolExists(toolId))
                return NotFound();

            var rating = _toolRepository.GetToolRating(toolId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }


    }
}
