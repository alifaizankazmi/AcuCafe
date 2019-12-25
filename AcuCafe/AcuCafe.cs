using System;

namespace AcuCafe
{
  public class AcuCafe
  {
    public static IDrink OrderDrink(string type, params string[] ingredients)
    {
      var drinkBuilder = new DrinkBuilder();
      try
      {
        drinkBuilder.StartBuilding(type);

        foreach (var ingredient in ingredients)
        {
          drinkBuilder.Add(ingredient);
        }

        Console.WriteLine(DrinkPrettyPrinter.PrettyPrint(drinkBuilder.Drink));
      } catch (Exception ex)
      {
        Console.WriteLine("We are unable to prepare your drink");
        Console.WriteLine(ex);

        System.IO.File.WriteAllText(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
          "\\AcuCafe.txt", ex.ToString());
      }

      return drinkBuilder.Drink;
    }
  }
}