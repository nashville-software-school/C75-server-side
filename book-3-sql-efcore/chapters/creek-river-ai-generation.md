### AI Agent Prompt Challenge: Generate Creek River

Now, create a new folder and open it in VS Code. Try to write a prompt that will get an AI agent to generate a .NET codebase similar to what you created in the Creek River project. Do what you can. After the agent is finished, you should try to run it and compare it with your own code.

You might want to manually modify the code. Or you can always delete the files generated, tweak your prompt, and try again. This process can take some trial and error, and the goal is more about getting a feel for the workflow and how AI works than about getting a specific result.

If you need some guidance, click on Hint #1 to get an outline of a suggested prompt. If you're stumped or want to compare with a successful prompt, click on Hint #2.

Note: Roo can have trouble executing commands in the terminal, so you might want to append something like this in your prompt:
```
In this process, please read, edit and create new folders and files. If you need to otherwise execute something on the command line, instead provide it to me and I will enter that myself.
```

<details>
<summary>Hint 1: Prompt Outline</summary>

Create a .NET Web API for a campground reservation system called Creek River with the following requirements:

The system should manage campsites, where each campsite has:

{describe each property on a separate line}


Implement campsite types with:

{describe each property on a separate line}

Allow users to:

{describe each user interaction on a separate line}

Technical requirements:

{try characterize the libraries and coding style we use. This can be difficult without broader experience, but give it a try}

{I needed to add the following because it was having trouble executing commands in the terminal}

In this process, please read, edit and create new folders and files. If you need to otherwise execute something on the command line, instead provide it to me and I will enter that myself.

</details>

<details>
<summary>Hint 2: Full Prompt</summary>

Create a .NET Web API for a campground reservation system called Creek River with the following requirements:


The system should manage campsites, where each campsite has:

A unique nickname

An image URL

A campsite type (which determines pricing and max stay duration)

A visibility flag

Associated reservations


Implement campsite types with:

A name

Maximum allowed reservation days

Fee per night

Allow users to:

View all campsites and their details

Create, update, and delete campsites

Toggle campsite visibility

Make and cancel reservations

View all reservations with associated user and campsite information



Technical requirements:

Use minimal API syntax (not controllers)

Implement Entity Framework Core with PostgreSQL

Include DTOs for data transfer

Implement proper error handling

Enable CORS for development

Use proper data relationships (one-to-many, many-to-one)

Please implement the complete solution with models, DTOs, database context, and API endpoints.

</details>