﻿CREATE TABLE [dbo].[Memberships]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
