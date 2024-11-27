using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApp1.Data;
using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces;

public class IHM
{
    private readonly RecipeContext _context;

    public IHM(RecipeContext context)
    {
        _context = context;
    }

    public void Run()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Ajouter une recette");
            Console.WriteLine("2. Afficher toutes les recettes");
            Console.WriteLine("3. Supprimer une recette");
            Console.WriteLine("4. Quitter");
            Console.Write("Choix: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRecipe();
                    break;
                case "2":
                    DisplayRecipes();
                    break;
                case "3":
                    DeleteRecipe();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Choix invalide !");
                    break;
            }
        }
    }

    private void AddRecipe()
    {
        // Récupération des informations de base de la recette
        Console.Write("Nom de la recette: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Temps de préparation (en minutes): ");
        int prepTime = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Temps de cuisson (en minutes): ");
        int cookTime = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Difficulté (facile, moyen, difficile): ");
        string difficulty = Console.ReadLine() ?? "";

        // Création de la recette
        Recipe recipe = new()
        {
            Name = name,
            PrepTime = prepTime,
            CookTime = cookTime,
            Difficulty = difficulty
        };

        // Ajout des ingrédients à la recette
        Console.WriteLine("Ajout d'ingrédients à la recette.");
        bool addingIngredients = true;
        while (addingIngredients)
        {
            Console.Write("Nom de l'ingrédient (laisser vide pour arrêter): ");
            string ingredientName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                addingIngredients = false;
            }
            else
            {
                recipe.Ingredients.Add(new Ingredient { Name = ingredientName });
            }
        }

        // Ajout des étapes à la recette
        Console.WriteLine("Ajout des étapes à la recette.");
        bool addingSteps = true;
        while (addingSteps)
        {
            Console.Write("Description de l'étape (laisser vide pour arrêter): ");
            string stepDescription = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(stepDescription))
            {
                addingSteps = false;
            }
            else
            {
                recipe.Steps.Add(new Step { Description = stepDescription });
            }
        }

        // Ajout à la base de données
        _context.Recipes.Add(recipe);
        _context.SaveChanges();

        Console.WriteLine("Recette ajoutée avec succès !");
    }


    private void DisplayRecipes()
    {
        var recipes = _context.Recipes.ToList();
        foreach (var recipe in recipes)
        {
            Console.WriteLine($"- {recipe.Name}: Préparation {recipe.PrepTime} min, Cuisson {recipe.CookTime} min, Difficulté: {recipe.Difficulty}");
        }
    }

    private void DeleteRecipe()
    {
        Console.Write("ID de la recette à supprimer: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var recipe = _context.Recipes.Find(id);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
            Console.WriteLine("Recette supprimée !");
        }
        else
        {
            Console.WriteLine("Recette introuvable !");
        }
    }
}

