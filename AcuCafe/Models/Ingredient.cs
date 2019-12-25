namespace AcuCafe
{
  public class Ingredient
  {
    public string Description { get; }

    public double Cost { get; }

    public Ingredient(string description, double cost)
    {
      Description = description;
      Cost = cost;
    }
  }
}
