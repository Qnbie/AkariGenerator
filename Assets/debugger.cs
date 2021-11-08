using System.Collections;
using System.Collections.Generic;
using Algorithms;
using UnityEngine;
using UnityEngine.Assertions;
using Utils.DataStructures;
using Utils.Enums;
using Utils.TestData;

public class debugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AlgorithmController algorithmController = new AlgorithmController();
        var puzzle = algorithmController.GetPuzzle(new Vector2Int(5, 5), Difficulty.Easy);
        Debug.Log(puzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
