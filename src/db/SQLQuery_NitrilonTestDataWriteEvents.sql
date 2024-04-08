-- EVENTS
INSERT INTO dbo.Events (Date, Name, Attendees, Description)
VALUES ('2024-12-31', 'Tour De Boom', 1, 'Vær med til et BRAG af en fest hos mig, please, jeg er så ensom...'),
('2024-06-22', 'SOMMER FEST D&D CULT', 18, 'SÅ ER DER SOMMMMEEEERRRR FFEEEERRRIIIIEEE!!!'),
('2024-06-23', 'KBH tur', 2, 'Party all week');

-- RATINGS
INSERT INTO dbo.Ratings (Value, Description)
VALUES (1, 'If I could give it a lower rating I would...'),
(2, 'Pretty mid ngl.'),
(3, 'BEST DAY EVUR ¯\_(ツ)_/¯');

-- EVENT-RATINGS
-- It just works
DECLARE @count INT = 0;
WHILE @count < 10
BEGIN
	INSERT INTO dbo.EventRatings (EventId, RatingId)
	-- VALUES (1,(FLOOR(RAND()*(3-1+1)+1)));
	VALUES ((FLOOR(RAND()*(3-1+1)+1)),(FLOOR(RAND()*(3-1+1)+1)));
	SET @count = @count + 1;
END;