using System.Collections.Generic;

namespace AcuCafe
{
  public interface IDrink
  {
    string Description { get; }
    List<Ingredient> Ingredients { get; }

    double GetCost();
    void Add(Ingredient ingredientToAdd);
  }
}
