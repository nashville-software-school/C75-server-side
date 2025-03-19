### AI Agent Prompt Challenge: Generate Honey Rae's API

Now, create a new folder and open it in VS Code. Try to write a prompt that will get an AI agent to generate a .NET codebase similar to what you created in Thrown for a Loop. Do what you can. After the agent is finished, you should try to run it and compare it with your own code.

You might want to manually modify the code if the functionality isn't what you expected, if it uses syntax you don't understand, or if you don't like the coding style. Or you can ask it to explain any part of it. Or you can always delete the files generated, tweak your prompt, and try again. This process can take some trial and error, and the goal is gaining a feel for the workflow and how AI works, not getting a specific result.

If you need some guidance, click on Hint #1 to get an outline of a suggested prompt. If you're stumped or want to compare with a successful prompt, click on Hint #2.

Note: Roo can have trouble executing commands in the terminal, so you might want to append something like this in your prompt:
```
In this process, please read, edit and create new folders and files. If you need to otherwise execute something on the command line, instead provide it to me and I will enter that myself.
```

<details>
<summary>Hint 1: Prompt Guidance</summary>

Instruct the agent to build all models, with specified property names and types
Have it create and then use DTOs

Detail the API endpoints with a few word summary about what each should do

Add any implementation requirements, features and code style specifications

Make sure it initializes the DB with test data

</details>

<details>
<summary>Hint 2: Full Prompt</summary>

Create a C# Web API project for a repair shop service management system called "Honey Rae's Repairs". The application should follow these specifications:

Create a Customer model with these properties:
   - Id (int)
   - Name (string)
   - Address (string)
   Include a List<ServiceTicket> property for related tickets

Create an Employee model with these properties:
   - Id (int)
   - Name (string)
   - Specialty (string)
   Include a List<ServiceTicket> property for assigned tickets

Create an ServiceTicket model with these properties:
   - Id (int)
   - CustomerId (int)
   - EmployeeId (int, nullable)
   - Description (string)
   - Emergency (bool)
   - DateCompleted (DateTime?, nullable)
   Include navigation properties for Customer and Employee

Create a DTO for each of these in a folder nested within the Models folder, and use those for all endpoints. 

API Requirements:
Implement the following endpoints:
   GET /customers - List all customers with their service tickets
   GET /customers/{id} - Get customer by id with their tickets
   GET /employees - List all employees with their assigned tickets
   GET /employees/{id} - Get employee by id with their tickets
   GET /servicetickets - List all service tickets with customer and employee details
   GET /servicetickets/{id} - Get service ticket by id
   POST /servicetickets - Create a new service ticket
   PUT /servicetickets/{id} - Update a service ticket (assign employee or mark complete)

Data Relationships:
   - One-to-Many between Customer and ServiceTickets
   - One-to-Many between Employee and ServiceTickets

Implementation Details:
   - Use .NET 6+ Web API project structure
   - Implement in-memory data storage (no database)
   - Use proper HTTP status codes (200, 201, 204, 404, etc.)
   - Implement proper model validation
   - Use async/await pattern for all controller methods
   - Include XML comments for API documentation
   - Implement proper error handling and null checks
   - Use DTOs for all API responses to shape the data appropriately

Data Initialization:
   - Include sample data for testing: 3 customers, 2 employees, and 4 tickets

Please implement this API following C# best practices, proper separation of concerns, and RESTful principles. The code should be well-commented and include appropriate error handling.

</details>