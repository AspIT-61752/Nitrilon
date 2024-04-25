namespace Nitrilon.Entities
{
    public class EventRatingData
    {
        private int badRatingCount;
        private int neutralRatingCount;
        private int goodRatingCount;

        /// <summary>
        /// The constructor for the EventRatingData class
        /// </summary>
        /// <param name="badRatingCount">The number of bad ratings for the event</param>
        /// <param name="neutralRatingCount">The number of neutral ratings for the event</param>
        /// <param name="goodRatingCount">The number of good ratings for the event</param>
        public EventRatingData(int badRatingCount, int neutralRatingCount, int goodRatingCount)
        {
            BadRatingCount = badRatingCount;
            NeutralRatingCount = neutralRatingCount;
            GoodRatingCount = goodRatingCount;
        }

        public (double badRatingPercentage, double neutralRatingPercentage, double goodRatingPercentage) GetPercentages()
        {
            (double, double, double) percentages = (0, 0, 0);

            /*
             * 1. Make a variable that will hold the total rating count.
             * 2. Calculate the percentage for each rating.
             * totalCount = BadCount + NeutralCount + GoodCount;
             * BadRating = BadCount / totalCount * 100;
             * 3. Return the percentages.
             */

            return percentages;
        }

        public int BadRatingCount { get => badRatingCount; set => badRatingCount = value; }
        public int NeutralRatingCount { get => neutralRatingCount; set => neutralRatingCount = value; }
        public int GoodRatingCount { get => goodRatingCount; set => goodRatingCount = value; }
    }
}
