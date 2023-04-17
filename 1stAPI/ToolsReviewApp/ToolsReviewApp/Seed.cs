using ToolsReviewApp.Data;
using ToolsReviewApp.Models;
using System.Diagnostics.Metrics;
using ToolsReviewApp.Data;
using ToolsReviewApp.Models;

namespace ToolsReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.ToolOwners.Any())
            {
                var pokemonOwners = new List<ToolOwner>()
                {
                    new ToolOwner()
                    {
                        Tool = new Tool()
                        {
                            Name = "ScrewDriver",
                            Withdraw = new DateTime(2023,1,1),
                            ToolCategories = new List<ToolCategory>()
                            {
                                new ToolCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Screwdriver",Text = "A eletric screwdriver", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            Job = "Mechanic",
                            Companie = new Companie()
                            {
                                Name = "I-DUTTO"
                            }
                        }
                    },
                    new ToolOwner()
                    {
                        Tool = new Tool()
                        {
                            Name = "Hammer",
                            Withdraw = new DateTime(2023,1,2),
                            ToolCategories = new List<ToolCategory>()
                            {
                                new ToolCategory { Category = new Category() { Name = "Wood"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Hammer", Text = "A wood hammer", Rating = 8,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            Job = "Brick Layer",
                            Companie = new Companie()
                            {
                                Name = "Boeing"
                            }
                        }
                    }
                };
                dataContext.ToolOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}