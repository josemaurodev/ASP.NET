using ToolsReviewApp.Models;

namespace ToolsReviewApp.Interface
{
    public interface IToolRepository
    {
        ICollection<Tool> GetTools();
        Tool GetTool(int id);
        Tool GetTool(string name);
        decimal GetToolRating(int ToolId);
        bool ToolExists(int ToolId);
    }
}
