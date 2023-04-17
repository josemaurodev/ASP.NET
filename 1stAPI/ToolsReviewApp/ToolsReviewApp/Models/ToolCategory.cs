namespace ToolsReviewApp.Models
{
    public class ToolCategory
    {
        public int ToolId { get; set; }
        public int CategoryId { get; set; }

        public Tool Tool { get; set; }
        public Category Category { get; set; }  

    }
}
