using ToolsReviewApp.Models;

namespace ToolsReviewApp.Interface
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();

        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfATool(int toolId);
        ICollection<Tool> GetToolByOwner(int ownerId);

        bool OwnerExists(int ownerId);
    }
}
