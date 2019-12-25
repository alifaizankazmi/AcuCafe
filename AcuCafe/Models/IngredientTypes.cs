using System.Collections.Generic;

public static class IngredientTypes
{
  public const string Chocolate = "Chocolate";
  public const string Milk = "Milk";
  public const string Sugar = "Sugar";

  public static List<string> All = new List<string>
  {
    Chocolate, 
    Milk, 
    Sugar
  };
}