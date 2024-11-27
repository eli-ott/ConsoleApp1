using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;

namespace ConsoleApp1.Data;

public class RecipeContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=recipes.db");
    }
}
