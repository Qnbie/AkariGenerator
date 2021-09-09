using System.Collections.Generic;
using UnityEngine;

namespace Script.GameBoard
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameBoardStats")]
    public class GameBoardStats : ScriptableObject
    {
        public Vector2 size;
        public int[][] Board;
    }
}