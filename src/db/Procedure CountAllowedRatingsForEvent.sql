CREATE PROCEDURE CountAllowedRatingsForEvent
    @EventId INT
AS
BEGIN
    DECLARE @BadCount INT, @AverageCount INT, @GoodCount INT;

    SELECT @BadCount = COUNT(CASE WHEN RatingId = 1 THEN 1 ELSE NULL END),
           @AverageCount = COUNT(CASE WHEN RatingId = 2 THEN 1 ELSE NULL END),
           @GoodCount = COUNT(CASE WHEN RatingId = 3 THEN 1 ELSE NULL END)
    FROM EventRatings
    WHERE EventId = @EventId;

    SELECT @BadCount AS RatingBad,
           @AverageCount AS RatingAverage,
           @GoodCount AS RatingGood;
END