using System.Collections;
using System.Collections.Generic;
using Algorithms;
using UnityEngine;
using Utils.Enums;

public class debugger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ac = new AlgorithmController();
        var puzzle = ac.GetPuzzle(Difficulty.Easy);
        Debug.Log(puzzle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
