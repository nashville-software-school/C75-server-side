# Exomine API 
For this project, you should build the API for the Exomine React app we built in the first half of the course. Either choose a version that you worked on or talk to an instructor about getting another working codebase for the client side application.

## Project Set-Up
1. Start by creating a new Git repository within your cohort organization, then have all teammates clone it.
1. One person should set up a dotnet project in a new folder, as you have before, then commit that initial code.
1. Review your client-side code and list all the endpoints that you need to provide to replace the json-server that we put in place before.
1. Create a Git project board with all the issues to complete this API, then start assigning those.
1. Build the API. Please reach out to an instructor if you have questions or want to confirm that you're on the right track.

Note: it's easier to constantly check your work with Postman than to do it through the client application. If you define your requirements carefully, then once you have endpoints built, it should work smoothly with the existing React app.


## Additional Functionality

Once you have built the above MVP (a working C# CRUD API to replace the json-server placeholder we used before) please continue working on the following features, using the time you have to get as far as you can. You may divide and conquer as you see fit, just use good Git hygiene. 

Note: each of these tasks will require changes to the client and server. If you work on the server first, you can test it with Postman or Swagger. If you work on the client side, you can replace any fetch calls with hardcoded data until the server is ready.

1. **Production:** Each mineral at each facility should have a production rate value. Add a button in the UI that will simulate the passing of time, so each time it is clicked, every facility will increase its amount of each of its minerals by the corresponding production rate.

1. **Money:** Each facility and colony should have a balance. Each mineral should have a price. You should be able to add a number of units of each of a facility's minerals to the Space Cart. When you click the Purchase button, the system should deduct the total price from the colony's balance and add it to the facility's balance. Check that the colony has enough money before completing the transaction.

1. **Colonists:** Add a population value to each colony. Provide a form to update the population with a new value, and another form that will apply a tax to the population - the user should specify a value and the colony's money balance should be increased based on that value and the current population.

1. **Pirates!!!** With every purchase, there should be a random possibility that the money is transferred and the minerals are deducted but they are not added to the colony. Next, add an option in the Space Cart to hire security forces that will deduct a certain amount from the colony and prevent this possibility.

1. **Anything else?** Get imaginative. What other features might be interesting to add to this system?
