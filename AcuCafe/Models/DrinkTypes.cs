using System.Collections.Generic;

public static class DrinkTypes
{
  public const string Expresso = "Expresso";
  public const string IceTea = "Ice Tea";
  public const string HotTea = "Hot Tea";

  public static List<string> All = new List<string>
  {
    Expresso,
    IceTea,
    HotTea
  };
}