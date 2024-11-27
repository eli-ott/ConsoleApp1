using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using ConsoleApp1.Models;

namespace ConsoleApp1.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public string Difficulty { get; set; } = string.Empty;

    public List<Ingredient> Ingredients { get; set; } = new();
    public List<Step> Steps { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public Category? Category { get; set; }
}
