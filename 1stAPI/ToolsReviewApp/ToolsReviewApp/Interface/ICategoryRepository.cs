using ToolsReviewApp.Models;

namespace ToolsReviewApp.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Tool> GetToolsByCategory(int categoryId);
        bool CategoryExists(int id);

        bool CreateCategory(Category category);


    }
}
