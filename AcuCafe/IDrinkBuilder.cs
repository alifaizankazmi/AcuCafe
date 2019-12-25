namespace AcuCafe
{
  public interface IDrinkBuilder
  {
    IDrink Drink { get; }
    void StartBuilding(string drinkType);
    IDrink Add(string ingredientType);
  }
}