using NUnit.Framework;
using System;

namespace AcuCafe.Tests.Tests
{
  [TestFixture]
  public class AcuCafeTest
  {
    private IDrinkBuilder drinkBuilder;

    [SetUp]
    public void SetUp()
    {
      drinkBuilder = new DrinkBuilder();
    }

    [Test]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Chocolate)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Milk)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Chocolate, IngredientTypes.Milk)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Chocolate, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Milk, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.Expresso, IngredientTypes.Chocolate, IngredientTypes.Milk, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.HotTea, IngredientTypes.Milk)]
    [TestCase(DrinkTypes.HotTea, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.HotTea, IngredientTypes.Milk, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.IceTea, IngredientTypes.Sugar)]
    public void CanCreateDrinkWithValidIngredientsTest(
      string drinkType,
      params string[] ingredients)
    {
      var drink = AcuCafe.OrderDrink(drinkType, ingredients);

      Assert.AreEqual(drinkType, drink.Description);
    }

    [Test]
    [TestCase(IngredientTypes.Milk)]
    [TestCase(IngredientTypes.Chocolate)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Milk)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Sugar)]
    [TestCase(IngredientTypes.Sugar, IngredientTypes.Milk)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Sugar, IngredientTypes.Milk)]
    public void CannotCreateIceTeaWithMilkOrChocolate(
      params string[] ingredients)
    {
      drinkBuilder.StartBuilding(DrinkTypes.IceTea);
      try
      {
        foreach (var ingredient in ingredients)
        {
          drinkBuilder.Add(ingredient);
        }
      } catch (Exception)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    [Test]
    [TestCase(IngredientTypes.Chocolate)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Milk)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Sugar)]
    [TestCase(IngredientTypes.Chocolate, IngredientTypes.Milk, IngredientTypes.Sugar)]
    public void CannotCreateTeaWithChocolate(
      params string[] ingredients)
    {
      drinkBuilder.StartBuilding(DrinkTypes.HotTea);
      try
      {
        foreach (var ingredient in ingredients)
        {
          drinkBuilder.Add(ingredient);
        }
      } catch (Exception)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("Felix Felicis")]
    public void CannotCreateUnsupportedDrink(
      string unsupportedDrink)
    {
      try
      {
        drinkBuilder.StartBuilding(unsupportedDrink);
      }
      catch (Exception)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    [Test]
    [TestCase("Pumpkin Spice")]
    public void CannotCreateDrinkWithUnsupportedIngredient(
      params string[] ingredients)
    {
      drinkBuilder.StartBuilding(DrinkTypes.Expresso);
      try
      {
        foreach (var ingredient in ingredients)
        {
          drinkBuilder.Add(ingredient);
        }
      }
      catch (Exception)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    [Test]
    [TestCase(DrinkTypes.Expresso, 1.0, IngredientTypes.Chocolate)]
    [TestCase(DrinkTypes.Expresso, 1.5, IngredientTypes.Chocolate, IngredientTypes.Milk)]
    [TestCase(DrinkTypes.Expresso, 1.5, IngredientTypes.Chocolate, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.Expresso, 2.0, IngredientTypes.Chocolate, IngredientTypes.Milk, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.IceTea, 0.5, IngredientTypes.Sugar)]
    [TestCase(DrinkTypes.HotTea, 0.5, IngredientTypes.Milk)]
    [TestCase(DrinkTypes.HotTea, 1.0, IngredientTypes.Milk, IngredientTypes.Sugar)]
    public void CanCalculateCostOfDrinks(
      string drinkType,
      double expectedCost,
      params string[] ingredients
      )
    {
      var drink = AcuCafe.OrderDrink(drinkType, ingredients);

      Assert.AreEqual(expectedCost, drink.GetCost());
    }
  }
}