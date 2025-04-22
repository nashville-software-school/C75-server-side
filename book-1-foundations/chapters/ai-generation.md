### AI Agent Prompt Challenge: Generate Thrown for a Loop

Now, create a new folder and open it in VS Code. Try to write a prompt that will get an AI agent to generate a .NET codebase similar to what you created in Thrown for a Loop. Do what you can. After the agent is finished, you should try to run it and compare it with your own code.

You might want to manually modify the code if the functionality isn't what you expected, if it uses syntax you don't understand, or if you don't like the coding style. Or you can ask it to explain any part of it. Or you can always delete the files generated, tweak your prompt, and try again. This process can take some trial and error, and the goal is gaining a feel for the workflow and how AI works, not getting a specific result.

If you need some guidance, click on Hint #1 to get an outline of a suggested prompt. If you're stumped or want to compare with a successful prompt, click on Hint #2.

Note: Roo can have trouble executing commands in the terminal, so you might want to append something like this in your prompt:
```
In this process, please read, edit and create new folders and files. If you need to otherwise execute something on the command line, instead provide it to me and I will enter that myself.
```

<details>
<summary>Hint 1: Prompt Outline</summary>

Give a general command to create a C# program with a few words summarizing the domain (sporting goods)

Describe the data object class to create, and then tell the agent to create a list of instances.

Tell it to build the CLI and describe the various options. 

Add any particular functional or stylistic specifications and clarifications.

</details>

<details>
<summary>Hint 2: Full Prompt</summary>

Create a C# console application for a used sporting equipment store called 'Thrown for a Loop'. The application should:

Have a Product class with properties: Name (string), Price (decimal), Sold (bool), Material (string), StockDate (DateTime), ManufactureYear (int), and Condition (double)

Initialize a list of 6 different sporting equipment items (like football, baseball, etc.) with varied prices, materials, dates, and conditions

Implement a menu-driven interface with options to:

View all products (showing inventory value and names)
View detailed product information (including age and time in stock)
View latest products (items added in last 90 days)
Exit

This should be in a single program.cs file in the root of this folder.
Each of the view features should be implemented in a separate function.
Include error handling for invalid user inputs when selecting products.
The program should continue running until the user chooses to exit.

</details>