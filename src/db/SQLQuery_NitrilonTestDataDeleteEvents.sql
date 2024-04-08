DELETE FROM EventRatings
DBCC CHECKIDENT (EventRatings, RESEED, 0)

DELETE FROM Events
DBCC CHECKIDENT (Events, RESEED, 0)

DELETE FROM Ratings
DBCC CHECKIDENT (Ratings, RESEED, 0)

-- Events won't be removed unless this is here.
DELETE FROM Events
DBCC CHECKIDENT (Events, RESEED, 0)