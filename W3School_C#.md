IO

```c#
Console.WriteLine("Hello World!");  
Console.WriteLine("I will print on a new line.");
Console.Write("Hello World! ");
Console.Write("I will print on the same line.");  
Console.WriteLine("Enter username:");
```

How to read a int (by default only can read string)

```c#
Console.WriteLine("Enter your age:");
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Your age is: " + age);
```

```c#
string.Concat(firstName, lastName);
	equivalent to 
firstName + lastName
// interpolation
string name = $"My full name is: {firstName} {lastName}";
// Array
string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
foreach (type variableName in arrayName) 
{
  // code block to be executed
}
Other useful array methods, such as Min, Max, and Sum, can be found in the System.Linq namespace:
```

```csharp
// Create an array of four elements, and add values later
string[] cars = new string[4];

// Create an array of four elements and add values right away 
string[] cars = new string[4] {"Volvo", "BMW", "Ford", "Mazda"};

// Create an array of four elements without specifying the size 
string[] cars = new string[] {"Volvo", "BMW", "Ford", "Mazda"};

// Create an array of four elements, omitting the new keyword, and without specifying the size
string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
```

However, you should note that if you declare an array and initialize it later, you have to use the new keyword:



It is also possible to send arguments with the `*key: value*` syntax.

That way, the order of the arguments does not matter:



C# also provides a way to use short-hand / automatic properties, where you do not have to define the field for the property, and you only have to write `get;` and `set;` inside the property.



If you don't want other classes to inherit from a class, use the `sealed` keyword:



Abstract + regular => use keyword `abstract` and then override

All abstract => use keyword `interface` (we can also use multiple interface)

See https://www.w3schools.com/cs/cs_abstract.php



`enum` just like in `swift5`



The `finally` statement lets you execute code, after `try...catch`, regardless of the result:

```csharp
try
{
  int[] myNumbers = {1, 2, 3};
  Console.WriteLine(myNumbers[10]);
}
catch (Exception e)
{
  Console.WriteLine("Something went wrong.");
}
finally
{
  Console.WriteLine("The 'try catch' is finished.");
}
```