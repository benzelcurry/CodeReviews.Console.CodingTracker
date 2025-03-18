using CodingTracker;

DatabaseManager dbManager = new();
dbManager.EnsureDatabaseExists();

UserInterface userInterface = new();
userInterface.MainMenu();
