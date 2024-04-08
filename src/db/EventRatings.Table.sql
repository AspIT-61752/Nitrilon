CREATE TABLE EventRatings
(
	[EventRatingId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [EventId] INT NOT NULL, 
    [RatingId] INT NOT NULL, 
    CONSTRAINT FK_EventRatings_Events FOREIGN KEY (EventId) REFERENCES Events(EventId),
	CONSTRAINT FK_EventRatings_Ratings FOREIGN KEY (RatingId) REFERENCES Ratings(RatingId)
)
