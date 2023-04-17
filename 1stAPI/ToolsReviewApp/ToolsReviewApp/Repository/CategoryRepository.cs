using ToolsReviewApp.Data;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            //Change Tracker
            //O change tracker vai ver se esta adding, updating ou modifiyng o que vem abaixo
            //Tambem vai verificar se esta conectado ou nao

            _context.Add(category);

            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Tool> GetToolsByCategory(int categoryId)
        {
            return _context.ToolCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Tool).ToList();
        }

    }
}
