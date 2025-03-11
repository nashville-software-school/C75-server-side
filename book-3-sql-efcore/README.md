
# DONE:
1. soft delete (inactive flag) - add to end of creek river. make sure it still works with related data cascade-deleting
2. regression and different DTOs - create an exception with an existing DTO and resolve with a new one (see late fees)
3. algorithmic thinking - see overdue items and add this kind of explanation in creek
4. add 90s tv
5. get form working
6. add Cors in creek river lesson
8. calculated property for total fees
9. write lesson for client, with instructions for features to add



# Book 3 - Managing Data with SQL and Entity Framework Core

Up until now in the server-side course, we have been using variables in our programs to store the data for our applications (storing the data _in-memory_). Of course, this doesn't work in real-life situations. It's rare that applications like those that we're building don't require permanent data storage. When you shut down the apps that you've built thus far, any changes to them are discarded along with any other data the application stored in your computer's memory while it was running. 

In the front-end course, you used a JSON data file to store data (and data changes!) that will persist between runs of the application. In this book you will learn to use a number of other technologies to do this instead of using JSON Server:
1. **PostgreSQL** - a relational database that will store data in a number of files in a directory on your computer.  PostgreSQL is an application that can read and write data to those files, and is listening for network requests to do those operations. 
1. **SQL** - (Structured Query Language) a language used by many relational databases to provide the ability to _query_ the data stored in the database, as well as make changes to that data. Every relational database implements SQL slightly differently, though the skills learned in using one system largely transfer to the others, especially at the conceptual level (but largely the syntax as well). Some other relational databases are called Oracle, SQL Server, and MySQL.
1. **Entity Framework Core** - EF Core is a set of .NET packages that allow your .NET application to send _SQL queries_ to the _PostgreSQL_ server. _Postgres_ will execute that query, and return the data, if any, that the query produced. EF Core will receive that response, and turn the data into C# objects that you can use in your application. Technologies like EF Core are called _Object Relational Mapping_ frameworks, or ORMs. 

Because of the large scope of this book, it is split into three parts, roughly corresponding to the three technologies above. Start with the installations, and work your way down. Complete every column in a specific part before moving on to the next part:

|[Installations for Book 3](./chapters/book-3-installs.md) :computer: |
|--|

## I. Learning to write SQL

|:zap: [Getting started with SQL Bolt](https://sqlbolt.com/)|
|-|
|:elephant: [Creating a PostgreSQL database using pgAdmin](./chapters/music-history-setup.md)|
|:headphones: [Music History](./chapters/music-history-practice.md) |
|:page_with_curl: [Using SQL scripts to create databases](./chapters/poki-setup.md)|
|:black_nib: [Poems By Kids](./chapters/poki-practice.md)|

## II. Querying a SQL database from a Web API
| # |🍯💻 Honey Rae's API|
|-|-|
|1| [Creating a database for Honey Rae's API](./chapters/honey-rae-database.md) |
|2| [Using Npgsql to make our first query](./chapters/honey-res-npgsql.md) |
|3| [Getting related data](./chapters/honey-raes-related-data.md) |
|4| [Inserting and Updating rows](./chapters/honey-raes-create.md) |
|5| [Deleting a row](./chapters/honey-raes-delete.md) |


## III. Entity Framework Core
|#|:tent: <br> Creek River Campground <br> (guided tour) | 
|:-:|:-:|
|1| [Project Setup](./chapters/creek-river-setup.md) |
|2| [Creating the database](./chapters/creek-river-db-context.md) <br><sub style="font-size: 0.85rem;">#encapsulation #inheritance #protected #override #constructor #base</sub>|
|3| [Get campsites](./chapters/creek-river-get-campsites.md) <br><sub style="font-size: 0.85rem;">#Include #Single</sub>|
|4| [Create a campsite](./chapters/creek-river-create-campsite.md) |
|5| [Delete a campsite](./chapters/creek-river-delete-campsite.md) |
|6| [Update a campsite](./chapters/creek-river-campsite-update.md) |
|7| [Get reservations](./chapters/creek-river-get-reservations.md) <br><sub style="font-size: 0.85rem;">#ThenInclude #OrderBy </sub>|
|8| [Book reservations](./chapters/creek-river-book-reservation.md) |
|9| [Deactivate a campsite](./chapters/creek-river-campsite-deactivate.md) |
|10| [Calculating fees](./chapters/creek-river-calculated.md) <br><sub style="font-size: 0.85rem;">#field #static #private</sub>|
|11|[Inheritance](https://github.com/nashville-software-school/bangazon-inc/blob/server-side-curriculum/book-1-orientation/chapters/INHERITANCE_INTRO.md)|
|12|[Client Side](./chapters/creek-river-client.md)|
|13|:tv:[Advanced Linq: Nineties TV](https://github.com/nashville-software-school/bangazon-inc/blob/server-side-curriculum/book-1-orientation/chapters/LINQ_INTRO.md)|

<!-- 
:tv:[Advanced Linq: Nineties TV](https://github.com/nashville-software-school/bangazon-inc/blob/server-side-curriculum/book-1-orientation/chapters/LINQ_INTRO.md)|:convenience_store:[Coding Self-Assessment](./chapters/book-3-coding-assessment.md)| -->

## Troubleshooting Entity Framework Issues

| Issue | Resolution |
|---|---|
| Cannot apply migrations because of pending changes to DBContext | [Override OnConfiguring](./chapters/UPDATE_DBCONTEXT.md) |

## 🔍 Additional Materials
|:compass: Explorer Chapters|
|-|
| :book: [Automapper to Map Models to DTO's](./chapters/loncotes-automapper.md) |
|🍯 💻 [Handling Related Data On Delete](./chapters/honey-raes-cascade-delete.md) |
|🍯 💻 [Finishing Honey Rae's with Npgsql](./chapters/honey-raes-complete.md) |
|🍯 💻 [Organize Data Access with Repositories](./chapters/honey-raes-repositories.md) |
|:tent: [Data Validation and Algorithmic Reasoning](./chapters/creek-river-reservation-validation.md) |
|:haircut:[Direct Many-To-Many](./chapters/hillarys-inferred-many-to-many.md)|


|:gear: Object-Oriented Programming |
|-|
| [Classes](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes) |
|[OOP in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop) |

|:test_tube: Projects|
|-|
|[Adventurer's Quest](https://github.com/nashville-software-school/bangazon-inc/blob/server-side-curriculum/book-1-orientation/chapters/QUEST.md) (practice with fields and constructors)|
