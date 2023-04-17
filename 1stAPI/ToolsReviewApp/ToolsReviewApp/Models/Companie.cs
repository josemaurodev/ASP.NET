namespace ToolsReviewApp.Models
{
    public class Companie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
