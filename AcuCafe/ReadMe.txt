AcuCafe has an ordering system which is poorly designed and sometime fails to deliver the right orders. For example, some of the clients complaint that their ice tea had milk in it. Also, the system turned out to be a maintenance nightmare as it is difficult to add new drinks.

AcuCafe has selected you to update their ordering system to be able to:
-	Stop the preparation of an ice tea with milk and inform the barista
-	Add a new chocolate topping to the expresso
Can you think of any new requirements that can impact your design?

Ensure you commit the completed code into GitHub and send us a link to a public repository. Please register a GitHub account if you don't already have one.
Hints:
We are looking for a solution that shows a good understanding of the SOLID principles, object oriented programming and that displays a working knowledge of TDD.
Please add some commentary to justify the decisions you've taken, if possible by quoting books, blog posts or talks that have influenced you.

Candidate's comments:

Design Pattern: 
	The drink preparation phase yields itself nicely to the builder design pattern 
	since there is scope for adding any number of ingredients to each drink - with two known restrictions.
	Note that I've assumed the chocolate ingredient can NOT be added to Ice Tea and Hot Tea.
	It is because of this variability of ingredients that we cannot use the Factory pattern and introduce
	drink-specific factories. There's a bit of ugliness in the DrinkBuilder class: any object using
	the builder needs to first call the StartBuilding function since the type of the drink that is being
	prepared will determine what ingredients can be added to it.
Dedicated Types for each Drink: 
	I did not see a need to represent each type of drink using its own type since based on the current design
	there is no information that requires a type to be captured. There may have been a need for dedicated drink
	types if, say, we wanted each drink type to define its own list of invalid ingredients - e.g., the IceTea 
	type could define a list of one ingredient: "Milk". In the current design, such logic has been moved to the
	DrinkBuilder class.
Dedicated Types for each Ingredient:
	It makes sense to refactor ingredients into their own types since each ingredient has a cost which will
	presumably stay the same across all instances of that ingredient's instances. This also simplifies the
	GetCost() function in the Drink class.
Using Strings Instead of Enums:
	Instead of using enums, I have used a class with static string fields to represent each drink and ingredient
	type. Where enums only let us define keys, this approach lets us define keys and values where the key is the
	field name and the value is the field value.
Prepare Function:
	The Prepare function that used to exist in the Drink class has been moved into the DrinkPrettyPrinter class.
	The Prepare function was making assumptions of the environment in which it was being used since it had a
	reference to the Console.WriteLine function. Such an assumption is better placed as close to the entry
	point of an application as possible, not deep inside domain-specific code. Regarding the actual function
	itself, I did not find it useful to print ingredients that were NOT going into the drink - which was the
	case in the Prepare function. The new function in DrinkPrettyPrinter only prints the ingredients that are
	going into the drink.
Adding New Drinks/Ingredients:
	The current design makes it relatively easy to add a new drink - you will need to add an entry to the
	DrinkTypes class. If the new drink has some restrictions in terms of ingredients then those restrictions
	will need to be added to DrinkBuilder. It is also easy to add new ingredients - add an entry to the
	IngredientTypes class and add another case statement to the IngredientRepository class.

While I did not look up any particular sources when coming up with this solution, a lot of the decisions I took
are probably influenced by what I've read in books such as "Clean Code" (Robert C. Martin) and "Refactoring"
(Kent Beck and Martin Fowler).