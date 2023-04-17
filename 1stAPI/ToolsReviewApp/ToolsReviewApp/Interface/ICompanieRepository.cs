using ToolsReviewApp.Models;

namespace ToolsReviewApp.Interface
{
    public interface ICompanieRepository
    {
        ICollection<Companie> GetCompanies();
        Companie GetCompanie(int id);
        Companie GetCompanieByOwner(int  ownerId);
        ICollection<Owner> GetOwnersFromACompanie(int companieId);
        bool CompanieExists(int companieId);

        bool CreateCompanie(Companie companie);

        bool Save();

    }
}
