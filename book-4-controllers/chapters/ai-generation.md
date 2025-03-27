### AI Agent Prompt Challenge: Generate Bianca's Bike Shop

Now, create a new folder and open it in VS Code. Try to write a prompt that will get an AI agent to generate a .NET codebase similar to what you created in Bianca's Bike Shop. Do what you can. After the agent is finished, you should try to run it and compare it with your own code.

You might want to manually modify the code if the functionality isn't what you expected, if it uses syntax you don't understand, or if you don't like the coding style. Or you can ask it to explain any part of it. Or you can always delete the files generated, tweak your prompt, and try again. This process can take some trial and error, and the goal is gaining a feel for the workflow and how AI works, not getting a specific result.

If you need some guidance, click on Hint #1 to get an outline of a suggested prompt. If you're stumped or want to compare with a successful prompt, click on Hint #2.

Note: Roo can have trouble executing commands in the terminal, so you might want to append something like this in your prompt:
```
In this process, please read, edit and create new folders and files. If you need to otherwise execute something on the command line, instead provide it to me and I will enter that myself.
```

<details>
<summary>Hint 1: Prompt Guidance</summary>

- The prompt should be clear and specific about the requirements
- Clearly define the data models and their properties
- Specify the required endpoints for each controller
- Include database context requirements
- Outline additional technical requirements
- Request proper implementation practices

</details>

<details>
<summary>Hint 2: Full Prompt</summary>

Create a .NET Web API for a bike shop management system with the following requirements:

Data Models:
- Bike model with properties for: Id (int), Brand (string), Color (string), Price (decimal), and IsNew (bool)
- UserProfile model with: Id (int), Name (string), Email (string), and IsAdmin (bool)
- WorkOrder model with: Id (int), Description (string), DateInitiated (DateTime), BikeId (int), UserProfileId (int),and IsComplete (bool)

Controllers:

BikeController with endpoints for:
- GET all bikes
- GET single bike by id
- POST to create a new bike
- PUT to update a bike
- DELETE to remove a bike

UserProfileController with endpoints for:
- GET all users
- GET single user by id
- POST to create a user
- PUT to update user details
- Additional endpoints for promoting/demoting admin status

WorkOrderController with endpoints for:
- GET all work orders
- GET work orders by user
- POST to create a work order
- PUT to update work order status
- DELETE to remove incomplete work orders

Database Context:
- Include DbSet properties for Bikes, UserProfiles, and WorkOrders
- Add example data for three UserProfiles, two Bikes per UserProfile, and five Workorders for different Bikes

Configure entity relationships:
- WorkOrder should have foreign keys to both Bike and UserProfile

Additional Requirements:
- Use Entity Framework Core for database operations
- Implement proper HTTP status codes for responses
- Include basic input validation
- Implement proper routing with [Route] attributes
- Include appropriate model DTOs for data transfer
- Please provide the complete code implementation including all necessary models, controllers, and DbContext. The solution should follow RESTful API best practices and include proper error handling.

</details>