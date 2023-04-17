using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsReviewApp.Dto;
using ToolsReviewApp.Data;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;
using ToolsReviewApp.Repository;

namespace ToolsReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanieController : ControllerBase
    {
        private readonly ICompanieRepository _companieRepository;
        private readonly IMapper _mapper;

        public CompanieController(ICompanieRepository companieRepository, IMapper mapper)
        {
            this._companieRepository = companieRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Companie>))]
        public IActionResult GetCompanies()
        {
            var companies = _mapper.Map<List<CompanieDto>>(_companieRepository.GetCompanies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companies);
        }

        [HttpGet("{companieId}")]
        [ProducesResponseType(200, Type = typeof(Companie))]
        [ProducesResponseType(400)]
        public IActionResult GetCompanie(int companieId)
        {
            if (!_companieRepository.CompanieExists(companieId))
                return NotFound();

            var companie = _mapper.Map<CompanieDto>(_companieRepository.GetCompanie(companieId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companie);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Companie))]

        public IActionResult GetCompanieOfAnOwner(int ownerId)
        {
            var companie = _mapper.Map<CompanieDto>(_companieRepository.GetCompanieByOwner(ownerId));

            if (!ModelState.IsValid) return BadRequest();

            return Ok(companie);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCompanie([FromBody] CompanieDto companieCreate)
        {
            if (companieCreate == null)
                return BadRequest(ModelState);

            var companie = _companieRepository.GetCompanies()
                .Where(c => c.Name.Trim().ToUpper() == companieCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (companie != null)
            {
                ModelState.AddModelError("", "Companie Already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companieMap = _mapper.Map<Companie>(companieCreate);

            if (!_companieRepository.CreateCompanie(companieMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving your category");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
