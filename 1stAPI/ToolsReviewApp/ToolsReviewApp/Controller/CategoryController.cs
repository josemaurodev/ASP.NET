using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsReviewApp.Data;
using ToolsReviewApp.Dto;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;
using ToolsReviewApp.Repository;

namespace ToolsReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("tool/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tool>))]
        [ProducesResponseType(400)]
        public IActionResult GetToolByCategoryId(int categoryId)
        {
            var tools = _mapper.Map<List<ToolDto>>(_categoryRepository.GetToolsByCategory(categoryId));

            if(!ModelState.IsValid)
                return BadRequest();    

            return Ok(tools);
        }

        //Chamada para criar
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if(categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories().Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (category != null)
            {
                ModelState.AddModelError("", "Category Already exists");
                return StatusCode(422, ModelState);
            }
                
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if (!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving your category");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
    
}
