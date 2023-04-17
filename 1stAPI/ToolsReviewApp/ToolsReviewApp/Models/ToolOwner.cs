namespace ToolsReviewApp.Models
{
    public class ToolOwner
    {
        public int ToolId { get; set; }
        public int OwnerId { get; set; }
        public Tool Tool { get; set; }
        public Owner Owner { get; set; } 
    }
}
