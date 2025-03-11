# Creek River React Client
Creek River has asked us to build a new client application. Initially, this will just be for the park rangers to use. Another developer on the team has already gotten started on the project, and you will pick it up from here. Go to [this](https://github.com/nashville-software-school/dotnet-creek-river-client) repo to get the template code to start the project. Follow the directions in the README to get it set up. The repo uses [`reactstrap`](https://reactstrap.github.io/?path=/story/home-installation--page), a library of Bootstrap-styled React components. If you wish, you can use it to add the new components you are going to build. It is also fine to not use it. Some of the styles from Bootstrap will be applied even if you don't use any `reactstrap` components. Reactstrap (and other component libraries) are worth getting familiar with, but you do not have to do so right away.  

## Dealing with CORS
Since we're building a front end and we'll need it to communicate with our server locally, we're going to hit CORS problems again. Let's resolve this the same way we did before. In `Program.cs` of your API code, add the following line below `builder.Services.AddSwaggerGen();`

``` csharp
builder.Services.AddCors();
```

Then, update the code that starts with `app.Environment.IsDevelopment()` with this code block:

``` csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
}
```

This should prevent the issue. If you still have problems with CORS, message an instructor.

## Exploring the existing repo
Examine the existing codebase and how it is structured. Pay particular attention to the following areas:
1. the `data` directory with the various managers. Try to use these manager modules to keep your `fetch` calls out of your components. 
1. `index.jsx` which holds the router and routes. 
1. the `components` directory, which is further separated into directories for different resources. There is only one, `materials` directory holding components related to that resource. 

If you have any questions about how the repo works, ask an instructor for help. 

## Currently implemented features
The first developer was able complete the following features:
1. display all circulating materials. 
1. create a new material
1. display a material's details

## Features to implement:
1. Add a component to show all users' basic info 
1. Add a component to show the details for a user, including their reservations if they have any
1. Add a form component to edit the name or email address of a user, and a link to this in each user's listing on the list page
1. Add a form to make a reservation, selecting an active campsite and a user (each with a select element), and entering check-in and check-out dates
1. Add a button labeled "Deactivate" to each of the campsites _that are active_ in the campsite list to deactivate that campsite. Use `onClick` with a handler to deactivate the campsite. Each inactive campsite should have a button to re-activate it. And the list should update immediately afterwards.
1. Add a component to show all reservations, with a button for each to delete that reservation.
1. Add an option on the campsites list component to hide all inactive campsites and another to hide all campsites with no pending reservations (checkout date is after today)


Up Next: [Advanced Linq](https://github.com/nashville-software-school/bangazon-inc/blob/server-side-curriculum/book-1-orientation/chapters/LINQ_INTRO.md) (this is another practice chapter from a different curriculum. Start on column 3 in this curriculum when you have finished the advanced linq practice)