namespace ToolsReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public Companie Companie { get; set; }

        public ICollection<ToolOwner> ToolOwners { get; set; }
    }
}
