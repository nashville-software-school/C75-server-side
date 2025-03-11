# Deactivate a Campsite

Earlier, we created an endpoint to delete a campsite. That's one way we could handle removing it from listings. But that could be problematic - what if we want to just remove it temporarily, or if we want to retain a record of previous reservations? Another way to solve this is with a _soft delete_, where we use a flag to indicate the record is inactive.

First, add a `bool` called isVisible to the Campsite model. 

``` csharp
    public bool isVisible { get; set; }
```

This will by get set to false by default. We want all new campsites to be enabled by default, so update the POST handler to set that to true:
``` csharp
app.MapPost("/api/campsites", (CreekRiverDbContext db, Campsite campsite) =>
{
    //if a campsite already exists with this nickname, say this this a bad request
    bool campsiteExists = db.Campsites.Any(c => c.Nickname == campsite.Nickname);
    if (campsiteExists) {
        return Results.BadRequest();
    }
    
    campsite.isVisible = true;
    db.Campsites.Add(campsite);
    db.SaveChanges();
    return Results.Created($"/api/campsites/{campsite.Id}", campsite);
});
```

Next, add this endpoint in our program file: 
``` csharp
app.MapPatch("/api/campsites/{id}/visible", (CreekRiverDbContext db, int id, Campsite campsite) =>
{
    Campsite campsiteToUpdate = db.Campsites.SingleOrDefault(campsite => campsite.Id == id);
    if (campsiteToUpdate == null)
    {
        return Results.NotFound();
    }
    campsiteToUpdate.isVisible = campsite.isVisible;

    db.SaveChanges();
    return Results.NoContent();
});
```

So we've made a change to our data model in the code... but our database still reflects the initial structure from when we set it up, so things will break. To remedy this we can reset the whole CreekRiver database. Don't worry about this - as long as we're just using test data in our development environment, we can just toss our database and rebuild it using a new migration.

First, open the pgAdmin client and right-click on _CreekRiver_ in the list of databases, then select delete. Next, delete the `Migrations` folder in your project. Finally, rebuild your migrations and then set up a new database based on the new structure, using the same commands as before:

```
dotnet ef migrations add InitialCreate
dotnet ef database update

```

Now you can test your new endpoint with a payload that looks something like this:
``` JSON
{
    "isVisible": false
}
```

Our new endpoint works just like a `PUT` endpoint, but since we're just making one little change, it's more appropriate to use the `PATCH` method. And since we don't need all the information about a campsite, this is an instance where we could use a different DTO for the payload parameter. First, create a new DTO called CampsiteVisibleDTO with only an id and an isVisible `bool`. Then replace the endpoint with this:

```
app.MapPatch("/api/campsites/{id}/visible", (CreekRiverDbContext db, int id, CampsiteVisibleDTO campsiteVisibleDTO) =>
{
    Campsite campsiteToUpdate = db.Campsites.SingleOrDefault(campsite => campsite.Id == id);
    if (campsiteToUpdate == null)
    {
        return Results.NotFound();
    }
    campsiteToUpdate.isVisible = campsiteVisibleDTO.isVisible;

    db.SaveChanges();
    return Results.NoContent();
});
```

This works the same, but it indicates that a client can use this endpoint by sending less data, which can make the transaction smaller and faster. It's not a big deal here, but in big business systems this can make a big difference. So it's common to create a number of DTOs for a resource for different parameters and return values of its endpoints.

# Changes elsewhere?
Making a change like allowing a resource to be deactivated can often affect other parts of our system. How are we going to deal with reservations for a deactivated campsite? How are we going to show or hide deactivated campsites in the UI? For this example we're not going to tackle all the changes. As an extra challenge you might want to explore this: first decide on the _business logic_ that you want, then consider the algorithm to achieve that, then implement it in your code. 

Up Next: [Calculating Fees](./creek-river-calculated.md)