using ToolsReviewApp.Data;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Repository
{
    public class ToolRepository : IToolRepository
    {
        private readonly DataContext _context;
        public ToolRepository(DataContext context) 
        {
            _context = context;
        }

        public Tool GetTool(int id)
        {
            return _context.Tools.Where(t => t.Id == id).FirstOrDefault();
        }

        public Tool GetTool(string name)
        {
            return _context.Tools.Where(t => t.Name == name).FirstOrDefault();
        }

        public decimal GetToolRating(int ToolId)
        {
            var reviews = _context.Reviews.Where(t => t.Tool.Id == ToolId);
            if(reviews.Count() <= 0) 
                return 0;

            return ((decimal)reviews.Sum(r => r.Rating)/reviews.Count());
        }

        public ICollection<Tool> GetTools()
        {
            return _context.Tools.OrderBy(t => t.Id).ToList();
        }

        public bool ToolExists(int ToolId)
        {
            return _context.Tools.Any(t => t.Id == ToolId);
        }
    }
}
