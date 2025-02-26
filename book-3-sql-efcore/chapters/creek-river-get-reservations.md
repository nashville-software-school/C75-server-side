# Getting Reservations with Related Data

Of course, we're also going to want to get our reservations. And we'll probably want more information than just what's stored in the reservation itself. We'll probably want the name of the person who placed the reservation, the campsite name, and fees, etc. To do this, we'll need to write a query that gets all this information. Before we write the code, let's take a moment to think this through in English. This is generally a good idea because solving the logical problem is one challenge, and translating that into specific instructions is another challenge. You'll save yourself a lot of grief by splitting these into two steps... especially at first, while you're still getting comfortable with both of these. So let's boil the process down to an _algorithm_.

1. First, we need to get all the Reservations.
2. For each reservation, we need to get information about its associated User
2. For each reservation, we need to get information about its associated Campsite
3. Once we have that campsite, we need to find the Campsite's CampsiteType
4. Then we'll compile the information from all of these
5. Finally, let's sort these by checkinDate.

Once we've clearly defined an algorithm. we can write the code to implement that. Add this endpoint to the project:
``` csharp
app.MapGet("/api/reservations", (CreekRiverDbContext db) =>
{
    return db.Reservations
        .Include(r => r.UserProfile)
        .Include(r => r.Campsite)
        .ThenInclude(c => c.CampsiteType)
        .OrderBy(res => res.CheckinDate)
        .Select(r => new ReservationDTO
        {
            Id = r.Id,
            CampsiteId = r.CampsiteId,
            UserProfileId = r.UserProfileId,
            CheckinDate = r.CheckinDate,
            CheckoutDate = r.CheckoutDate,
            UserProfile = new UserProfileDTO
            {
                Id = r.UserProfile.Id,
                FirstName = r.UserProfile.FirstName,
                LastName = r.UserProfile.LastName,
                Email = r.UserProfile.Email
            },
            Campsite = new CampsiteDTO
            {
                Id = r.Campsite.Id,
                Nickname = r.Campsite.Nickname,
                ImageUrl = r.Campsite.ImageUrl,
                CampsiteTypeId = r.Campsite.CampsiteTypeId,
                CampsiteType = new CampsiteTypeDTO
                {
                    Id = r.Campsite.CampsiteType.Id,
                    CampsiteTypeName = r.Campsite.CampsiteType.CampsiteTypeName,
                    MaxReservationDays = r.Campsite.CampsiteType.MaxReservationDays,
                    FeePerNight = r.Campsite.CampsiteType.FeePerNight
                }
            }
        })
        .ToList();
});
```

Here it might be helpful to imagine the SQL query that this method chain will produce:
1. The first `Include` will `JOIN` the `UserProfiles` table
1. The second `Include` will further `JOIN` the `Campsites` table
1. `ThenInclude` is called when you want to `JOIN` to a table that is not the original table. It must immediately follow the `Include` call that `JOIN`s the table that you wish to `JOIN` to. In this case, because we can only get to `CampsiteTypes` from `Campsites`, and not the original `Reservations` table, we call `ThenInclude` to add `CampsiteTypes` data to the `Campsites` data right after the `Include` call to `JOIN` `Campsites`
1. `OrderBy` is a regular Linq method (see the explorer chapter on advanced Linq!), but corresponds directly to the `ORDER BY` keywords in SQL. 
1. We create a new `ReservationDTO` for each reservation, and populate the `UserProfileDTO` and `CampsiteDTO` (and the `CampsiteDTO`'s `CampsiteTypDTO`!) data from the nested objects in the results.

The full SQL query this generates will be something like this:
``` sql
SELECT r.Id,
       r.CampsiteId,
       r.UserProfileId,
       r.CheckinDate,
       r.CheckoutDate,
       up.Id,
       up.FirstName,
       up.LastName,
       up.Email,
       c.Id, 
       c.Nickname
       c.ImageUrl,
       c.CampsiteTypeId, 
       ct.Id,
       ct.CampsiteTypeName,
       ct.MaxReservationDays,
       ct.FeePerNight
FROM Reservations r
LEFT JOIN UserProfiles up ON up.Id = r.UserProfileId
LEFT JOIN Campsites c ON c.Id = r.CampsiteId
LEFT JOIN CampsiteTypes ct ON ct.Id = c.CampsiteTypeId
ORDER BY r.CheckinDate;
```
Here you can see that we need `ThenInclude` for `CampsiteType` because the `JOIN` for it is not on a `Reservations` column but a `Campsites` column, and `ThenInclude` must be chained right after the `Include` that `JOIN`s `Campsites`, so that `ThenInclude` can determine which table it is joining from.  

## Testing the endpoint
Try the endpoint out. You will notice that the `reservations` property for the `userProfile` and `campsite` profile of each reservation is `null` in the JSON output. Here is an example:
``` json
{
    "id": 3,
    "campsiteId": 1,
    "campsite": {
        "id": 1,
        "nickname": "Barred Owl",
        "imageUrl": "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg",
        "campsiteTypeId": 1,
        "campsiteType": {
        "id": 1,
        "campsiteTypeName": "Tent",
        "maxReservationDays": 7,
        "feePerNight": 15.99
        },
        "reservations": null
    },
    "userProfileId": 1,
    "userProfile": {
        "id": 1,
        "firstName": "Admina",
        "lastName": "Strator",
        "email": "admina@creekriver.campground",
        "reservations": null
    },
    "checkinDate": "2023-06-30T00:00:00",
    "checkoutDate": "2023-07-02T00:00:00"
}
```
This is the expected behavior, because the framework will try to serialize every public property of a class instance to the JSON output. If we don't explicitly set the value of a property, the JSON will have the property's default value, which in the case of a `List` is `null`.

Up Next: [Booking Reservations](./creek-river-book-reservation.md)