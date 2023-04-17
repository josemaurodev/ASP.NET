namespace ToolsReviewApp.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Withdraw { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ToolOwner> ToolOwners { get; set; }
        public ICollection<ToolCategory> ToolCategories { get; set; }
    }
}
