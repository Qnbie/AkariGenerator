using System.Collections.Generic;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;
using Utils.StaticClasses;

namespace Algorithms
{
    public class PuzzleSolver
    {
        private Validator _validator;
        private PreProcessor _preProcessor;
        
        public PuzzleSolver(Validator validator)
        {
            _validator = validator;
            _preProcessor = new PreProcessor();
        }

        public List<Solution> FindSolutions(Puzzle puzzle)
        {
            Puzzle litPuzzle = _preProcessor.Process(puzzle);
            Debug.Log(litPuzzle);
            List<Vector2Int> solutionCandidates = new List<Vector2Int>();
            for (int x = 0; x < litPuzzle.SizeX(); x++)
            {
                for (int y = 0; y < litPuzzle.SizeY(); y++)
                {
                    if (litPuzzle.PuzzleMatrix[x][y] == TileStates.Empty)
                    {
                        solutionCandidates.Add(new Vector2Int(x,y));
                    } 
                    else if (litPuzzle.PuzzleMatrix[x][y] == TileStates.Implacable)
                    {
                        litPuzzle.PuzzleMatrix[x][y] = TileStates.Empty;
                    }
                }
            }
            Debug.Log("Solution candidates are ready");
            
            return BacktrackFunction(
                puzzle, 
                solutionCandidates,
                new Solution(puzzle.GetElementPositions(TileStates.Lamp)),
                new List<Solution>());
        }

        private List<Solution> BacktrackFunction(
            Puzzle puzzle,
            List<Vector2Int> candidates,
            Solution solution, 
            List<Solution> finalSolutions)
        {
            if (_validator.PuzzleIsSolved(puzzle, solution))
            {
                Debug.Log("Solution add");
                Debug.Log(solution);
                finalSolutions.Add(solution);
                return finalSolutions;
            }

            if (candidates.Count == 0 || WallsAreUnsatisfiable(puzzle, solution))
            {
                if (candidates.Count == 0)
                    Debug.Log("Candidates are empty");
                else
                    Debug.Log("Wall problem");
                return finalSolutions;
            }
            Vector2Int nextCandidate = candidates[0];
            candidates.Remove(nextCandidate);
            solution.Positions.Add(nextCandidate);
            finalSolutions = BacktrackFunction(puzzle, candidates, solution, finalSolutions);
            solution.Positions.Remove(nextCandidate);
            finalSolutions = BacktrackFunction(puzzle, candidates, solution, finalSolutions);
            return finalSolutions;
        }

        private bool WallsAreUnsatisfiable(Puzzle puzzle, Solution solution)
        {
            Puzzle litPuzzle = PuzzleUtil.TurnOnLamps(puzzle, solution);
            for (int x = 0; x < puzzle.SizeX(); x++)
            {
                for (int y = 0; y < puzzle.SizeY(); y++)
                {
                    if ((int) puzzle.PuzzleMatrix[x][y] >= 5) continue;
                    if (_validator.WallIsSatisfied(x, y, puzzle)) continue;
                    if (NoMoreSpace(x, y, puzzle))
                        return true;
                }
            }
            return false;
        }

        private bool NoMoreSpace(int posX, int posY, Puzzle puzzle)
        {
            int emptyCnt = 0;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX + 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX - 1, posY, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY + 1, TileStates.Empty)) emptyCnt++;
            if (PuzzleUtil.PlaceIsEqual(puzzle, posX, posY - 1, TileStates.Empty)) emptyCnt++;
            return emptyCnt == 0;
        }

        public int NumberOfDifferentSolution(List<Solution> solutions)
        {
            // TODO implement complex solution counter methode
            return solutions.Count;
        }
    }
}