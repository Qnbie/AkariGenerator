using System.Collections.Generic;
using Utils.Enums;
using Utils.StaticClasses;

namespace Source.Algorithms
{
    public class LevelCalculator
    {
        public Difficulty CalculateDifficultly(List<List<TileStates>> puzzle, int solutionsCnt)
        {
            int levelOfCompleteness = 0;

            foreach (List<TileStates> row in puzzle)
            {
                foreach (TileStates tileState in row)
                {
                    if (tileState == TileStates.Four || tileState == TileStates.Zero)
                        levelOfCompleteness++;
                    // TODO implement complex difficulty level calculator
                }
            }
            
            return MapperUtil.DifficultyFromLevel(levelOfCompleteness);
        }
        
        
    }
}