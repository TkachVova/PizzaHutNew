Basic information about project:
	Visual Studio 2013
	SQL Server 2012 (database backup added (PizzaHutDb.bak))
		
		
To start project in Visual Studio:
	Download project from GitHub as .zip
	Restore database (PizzaHutDb.bak)
	Open project in Visual Studio
	Build Solution (some packages will be installed from NuGet during first build)
	Run
		
PizzaHutNew and PizzaHutNew.WebApi are working together. (multiple start)	
PizzaHutNew.Domain is class lib which provides access to PizzaHutDb using Entity Framework. 
PizzaHutNew.Admin - project for administration of PizzaHutDb. 
All projects must be located in one parent path to provide images adding.


Changes between PizzaHut and PizzaHutNew:
	Added validation for user input
	Changed UI
	Fixed bug with multiple tabs (when order is sent from one tab and you try to send it from second)
	Now users are identified by their phone number (if some phone number is in database we don't create new user)
	Changes to admin application
	Trash is removed
	Language changed
	
Login params:
	Name: admin
	Password: secret