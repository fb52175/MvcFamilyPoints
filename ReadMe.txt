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

Week 4 - Added repositories and their interfaces to the FamilyPointService layer.  Created a RepositoryFactory class which creates or returns the repositories.
Added a unit test to test the RewardsRepository add/update/delete and list functions.  Updated the Home Controller to use the Repository Factory.                

Week 5 - Refactored the Repository Factory to be a decoupled factory.  
Added Business Managers to and used the facade pattern to implements some of the use cases.
I also renamed all the projects and namespaces to match the pattern application.layer, rather than applicationlayer.
I have corrected issues with DBContext in my unit test on the Family Object.  This was because I was creating a new dbcontext each time I hit a repository.
The service factory now accepts arguments, so that the dbcontext can be injected.

Week 6   - I refactored the Business layer managers to use the Super Type design pattern.  This allowed the creation of service factory to be moved to the super class.
I began work on the presentation layer.  I have created controllers and views for each of the domain objects in order to do CRUD operations.  
I modified the scaffolding to add a menu item to the list page for each domain object.  For the family domain object I modified the details view to show the parents and children associated to the family.
