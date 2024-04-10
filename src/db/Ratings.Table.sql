CREATE TABLE [dbo].[Ratings]
(
	[RatingId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [RatingValue] TINYINT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
