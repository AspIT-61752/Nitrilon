CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Membership] INT NOT NULL, 
    [FullName] NVARCHAR(128) NOT NULL, 
    [JoinDate] DATETIME NOT NULL, 
    [Email] NVARCHAR(128) NULL, 
    [PhoneNumber] NVARCHAR(16) NULL, 
    CONSTRAINT [FK_Members_Memberships] FOREIGN KEY ([Membership]) REFERENCES [dbo].[Memberships]([Id]),
)
