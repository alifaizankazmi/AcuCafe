using AcuCafe;
using System.Collections.Generic;
using System.Linq;

public class Drink: IDrink
{
  public string Description { get; }
  public List<Ingredient> Ingredients { get; }

  public Drink(string description)
  {
    Description = description;
    Ingredients = new List<Ingredient>();
  }

  public Drink(string description, List<Ingredient> ingredients)
  {
    Description = description;
    Ingredients = ingredients ?? new List<Ingredient>();
  }

  public void Add(Ingredient ingredientToAdd)
  {
    Ingredients.Add(ingredientToAdd);
  }

  public double GetCost()
  {
    return Ingredients.Sum(i => i.Cost);
  }
}