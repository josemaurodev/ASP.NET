using AutoMapper;
using ToolsReviewApp.Dto;
using ToolsReviewApp.Models;

namespace ToolsReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tool, ToolDto>();
            //Para ler a gente vai até o model, e pega somente o que esta no dto
            CreateMap<Category, CategoryDto>();
            //Para criar a gente vai até o Dto e ve o que pode ser atribuído pelo body
            CreateMap<CategoryDto, Category>();
            CreateMap<Companie, CompanieDto>();
            CreateMap<CompanieDto, Companie>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();


        }
    }
}
