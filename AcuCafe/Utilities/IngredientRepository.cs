namespace AcuCafe
{
  /* This class serves as a mock database in the sense
   * that it matches each ingredient type to its cost. Ideally,
     the application should have its own database and possibly
     use an ORM tool instead. */
  public class IngredientRepository
  {
    public static Ingredient GetIngredient(string ingredientType)
    {
      switch(ingredientType)
      {
        case IngredientTypes.Chocolate:
          return new Ingredient(ingredientType, 1.0);
        case IngredientTypes.Milk:
        case IngredientTypes.Sugar:
          return new Ingredient(ingredientType, 0.5);
        default:
          return null;
      }
    }
  }
}
