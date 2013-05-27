Author: Fred Boland
Class MSSE 680
-------------------------------------
This MVC application was developed using Entity Frameworks code-first development method.
The unit test poject has an initialization class (FamilyPointsContextInitializer) that will drop and create the database as needed for the testing.  It also seeds each table with an object.
The domain objects are included in the Domain namespace.  I have created one controller and view which demonstrates add/edit/delete a reward.

Week 3 - Refactored to move domain and domain test into their own projects.  

As in Week2, the unit test project has an initialization class which create and drops the database defined by the connection string in the app.config file.
It will also seed the database with objects for testing.

Each domain class had a test file, that tests inserting, updating and deleting an object.  It also test generating a list of objects.
There is one controller and view which demonstrates add/edit/delete a reward record.  You can access the view by running the project.

              

