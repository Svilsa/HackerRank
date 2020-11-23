using System;

namespace Utopian_Tree
{
    /// <summary>
    /// This class represents a Utopian Tree
    /// </summary>
    /// <remarks>
    /// This class predict Utopian Tree through seasons.
    /// </remarks>
    public class UtopianTree
    {
        private enum Seasons
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn
        }

        public int InitialHeight { get; }

        public UtopianTree(int initialHeight)
        {
            InitialHeight = initialHeight;
        }

        /// <summary>
        /// Predict the height of the tree through several seasons  
        /// </summary>
        /// <returns>
        /// The height of the tree through specified number of seasons.
        /// </returns>
        /// <param name="numberOfSeasons">A specified number of seasons</param>
        public int PredictGrowth(int numberOfSeasons)
        {
            var currentHeight = InitialHeight;
            var currentSeason = Seasons.Spring;

            for (var i = 0; i < numberOfSeasons; i++)
            {
                switch (currentSeason)
                {
                    case Seasons.Spring: currentHeight *= 2;
                        currentSeason = Seasons.Summer;
                        break;
                    case Seasons.Summer: currentHeight += 1;
                        currentSeason = Seasons.Spring;
                        break;
                }
            }
            return currentHeight;
        }
    }
}