using AutoMapper;
using ToolsReviewApp.Data;
using ToolsReviewApp.Interface;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Repository
{
    public class CompanieRepository : ICompanieRepository
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CompanieRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper; 
        }
        public bool CompanieExists(int companieId)
        {
            return _context.Companies.Any(c => c.Id == companieId);
        }

        public Companie GetCompanie(int companieId)
        {
            return _context.Companies.Where(c => c.Id == companieId).FirstOrDefault();
        }

        public Companie GetCompanieByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Companie).FirstOrDefault();
        }

        public ICollection<Companie> GetCompanies()
        {
           return _context.Companies.ToList();
        }

        public ICollection<Owner> GetOwnersFromACompanie(int companieId)
        {
            return _context.Owners.Where(c => c.Companie.Id == companieId).ToList();
        }

        public bool CreateCompanie(Companie companie)
        {
            _context.Add(companie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
