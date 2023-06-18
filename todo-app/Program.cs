Console.WriteLine("Hello!");

List<string> todos = new List<string>();
bool shouldExit = false;

while (!shouldExit)
{
	Console.WriteLine();
	Console.WriteLine("What do you want to do?");
	Console.WriteLine("[S]ee all todos");
	Console.WriteLine("[A]dd a todo");
	Console.WriteLine("[R]emove a todo");
	Console.WriteLine("[E]xit");

	string userChoice = Console.ReadLine();

	switch (userChoice)
	{
		case "E":
		case "e":
			shouldExit = true;
			break;

		case "S":
		case "s":
			SeeAllTodos();
			break;

		case "R":
		case "r":
			RemoveTodo();
			break;

		case "A":
		case "a":
			AddTodo();
			break;

		default:
			Console.WriteLine("Invalid choice");
			break;
	}
}

void SeeAllTodos()
{
	if (todos.Count == 0)
	{
		ShowNoTodosMessage();
		return;
	}

	for (int i = 0; i < todos.Count; i += 1)
	{
		Console.WriteLine($"{i + 1}. {todos[i]}");
	}
}

void RemoveTodo()
{
	if (todos.Count == 0)
	{
		ShowNoTodosMessage();
		return;
	}

	int index;

	do
	{
		Console.WriteLine("Select the index of the TODO you want to remove");
		SeeAllTodos();
	} while (!TryReadIndex(out index));

	RemoveTodoAtIndex(index - 1);
}

void AddTodo()
{
	string description;

	do
	{
		Console.WriteLine("Enter the TODO description:");

		description = Console.ReadLine();
	} while (!IsDescriptionValid(description));

	todos.Add(description);
}

void RemoveTodoAtIndex(int index)
{
	string removedTodo = todos[index];

	todos.RemoveAt(index);

	Console.WriteLine($"TODO removed: {removedTodo}");
}

bool TryReadIndex(out int index)
{
	string useInput = Console.ReadLine();

	if (useInput == "")
	{
		index = 0;

		Console.WriteLine("Selected index cannot be empty");

		return false;
	}

	if (int.TryParse(useInput, out index) && index >= 1 && index <= todos.Count)
	{
		return true;
	}

	Console.WriteLine("The given index is not valid");
	return false;
}

bool IsDescriptionValid(string description)
{
	if (description == "")
	{
		Console.WriteLine("The description cannot be empty");
		return false;
	}

	if (todos.Contains(description))
	{
		Console.WriteLine("The description must be unique");
		return false;
	}

	return true;
}

void ShowNoTodosMessage()
{
	Console.WriteLine("No TODOs have been added yet");
}