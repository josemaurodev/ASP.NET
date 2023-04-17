using ToolsReviewApp.Models;

namespace ToolsReviewApp.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public Companie Companie { get; set; }
    }
}
