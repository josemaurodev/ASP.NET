using AutoMapper;
using System.Linq;
using ToolsReviewApp.Data;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        
        
        private readonly DataContext _dataContex;

        public OwnerRepository(DataContext dataContex)
        {
            
            this._dataContex = dataContex;
        }
        public Owner GetOwner(int ownerId)
        {
            return _dataContex.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfATool(int toolId)
        {
            return _dataContex.ToolOwners.Where(t => t.Tool.Id == toolId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _dataContex.Owners.ToList();
        }

        public ICollection<Tool> GetToolByOwner(int ownerId)
        {
            return _dataContex.ToolOwners.Where(t => t.Owner.Id == ownerId).Select(o => o.Tool).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _dataContex.Owners.Any(o => o.Id == ownerId);
        }
    }
}
