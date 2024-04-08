CREATE TABLE Events
(
	[EventId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Date] DATE NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Attendees] INT NULL DEFAULT -1, 
    [Description] NTEXT NULL DEFAULT 'Dette event har endnu ingen beskrivelse.'
)
