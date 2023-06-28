# LibApp

This features the use of Code-First Migrations to create our database, and WebAPI and LINQ to perform CRUD operations.



# Running this project 
- Project > LibApp Properties > Change target framework to 4.7.1 -> Change back to 4.7.2
- Make sure there is an App_Data folder in the project (Right click solution > View in File Explorer)
- Tools > Nuget Package Manager > Package Manage Console > Update-Database
- Check that the database is created using (View > SQL Server Object Explorer > MSSQLLocalDb > ..)
- Run API commands through CURL to create new books


Get a List of Bookas
curl https://localhost:44370/api/bookdata/listbooks

Get a Single Book
curl https://localhost:44370/api/bookdata/findbook/{id}

Add a new Book (new book info is in book.json)
curl -H "Content-Type:application/json" -d @animal.json https://localhost:44370/api/bookdata/addbook

Delete an Book
curl -d "" https://localhost:44370/api/bookdata/deletebook/{id}

Update an Book (existing book info including id must be included in book.json)
curl -H "Content-Type:application/json" -d @book.json https://localhost:44370/api/bookdata/updatebook/{id}

# Running the Views for List, Details, New
- Use SQL Server Object Explorer to add a new Publisher
- Take note of the Publisher ID
- Navigate to /Book/New
- Input the Name, Author, ISBN, Genre, and Publisher ID
- click "Add"
