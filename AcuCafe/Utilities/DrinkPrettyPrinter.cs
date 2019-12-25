using System.Linq;

namespace AcuCafe
{
  public class DrinkPrettyPrinter
  {
    public static string PrettyPrint(IDrink drink)
    {
      if(drink == null)
      {
        return string.Empty;
      }

      var message = $"We are preparing the following drink for you: {drink.Description} with ";
      message += string.Join(", ", drink.Ingredients.Select(i => i.Description));

      return message;
    }
  }
}
