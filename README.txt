ASP.NET with EntityFramework

This project are supposted to provide protected access to some functions in database. 
Therefore, I use roles to give some users (admins) the ability to do things that others can't.


Admin abilities: 
view all items in database
create new item
find some item
edit item in database
delete item from database

User abilities:
view all items in database
find some item 

The database contains 3 tables: Roles (admin & user), Users (admins' and users' logins and passwords), Phones and presents a database in mobile phone shop.
The new user is meant to be registed to look up the database context in the case he hasn't done it before.

admin@mail.com -- 123456 (give access as admin)
user22 -- 123123 (give access as user)

