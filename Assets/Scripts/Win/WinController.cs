using UnityEngine;
using Utils.Helpers;

namespace Win
{
    [RequireComponent(typeof(LevelLoader))]
    public class WinController : LevelLoader
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LoadNextLevel("MenuScene");
            }
        }
    }
}