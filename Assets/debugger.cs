using System.Collections;
using System.Collections.Generic;
using Algorithms;
using UnityEngine;
using UnityEngine.Assertions;
using Utils.DataStructures;
using Utils.Enums;

public class debugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var _puzzleSolver = new PuzzleSolver(new Validator());
        var tmpPuzzle = new Puzzle(new Vector2Int(3, 3));
        var solutions = _puzzleSolver.FindAllSolutionWithEmptyWalls(tmpPuzzle);
        Debug.Log($"\n3x3 middle wall test is done\n{tmpPuzzle}");
        Debug.Log(solutions.Count);
        foreach (var solution in solutions)
            Debug.Log(solution);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
