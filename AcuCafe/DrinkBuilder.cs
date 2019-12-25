using System;

namespace AcuCafe
{
  public class DrinkBuilder : IDrinkBuilder
  {
    public IDrink Drink { get; private set; }

    public void StartBuilding(string drinkType)
    {
      if(!DrinkTypes.All.Contains(drinkType))
      {
        throw new ArgumentException($"{drinkType} is not a supported drink");
      }

      Drink = new Drink(drinkType);
    }

    public IDrink Add(string ingredientType)
    {
      if (Drink == null)
      {
        throw new InvalidOperationException("Please call the StartBuilding function " +
          "before you call the Add function");
      }

      var ingredient = IngredientRepository.GetIngredient(ingredientType);

      if (ingredient == null)
      {
        throw new ArgumentException($"{ingredientType} is not a supported ingredient");
      }

      if(ingredient.Description == IngredientTypes.Milk &&
        Drink.Description == DrinkTypes.IceTea)
      {
        throw new InvalidOperationException($"Cannot add {IngredientTypes.Milk} to {DrinkTypes.IceTea}");
      }

      if(ingredient.Description == IngredientTypes.Chocolate &&
        Drink.Description != DrinkTypes.Expresso)
      {
        throw new InvalidOperationException($"{IngredientTypes.Chocolate} can only be added to {DrinkTypes.Expresso}");
      }

      Drink.Add(ingredient);

      return Drink;
    }
  }
}
