1. Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.
   
List<int> numbers = new List<int>();

Console.Write("How many numbers do you want to enter? ");
int size = Convert.ToInt32(Console.ReadLine());

try
{
	for (int i = 0; i < size; i++)
	{
		Console.Write("Enter number " + (i + 1) + ": ");
		int num = Convert.ToInt32(Console.ReadLine());

	
		for (int j = 0; j < numbers.Count; j++)
		{
			if (numbers[j] == num)
			{
				throw new Exception("Duplicate number detected: " + num);
			}
		}

		numbers.Add(num);
	}
}
catch (Exception ex)
{
	Console.WriteLine("Error: " + ex.Message);
}
////////////////////////////////////////////
2. Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.

	try
	{
		Console.Write("Enter a string: ");
		string text = Console.ReadLine();

		CheckVowels(text);

		Console.WriteLine("The string contain vowels");
	}
	catch (Exception ex)
	{
		Console.WriteLine("Error: " + ex.Message);
	}
}

static void CheckVowels(string str)
{
	string vowels = "aeiouAEIOU";

	for (int i = 0; i < str.Length; i++)
	{
		if (vowels.Contains(str[i]))
		{
			return;
		}
	}

	throw new Exception("The string does not contain any vowels.");
