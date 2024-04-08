CREATE TABLE [dbo].[Ratings]
(
	[RatingId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Value] TINYINT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
