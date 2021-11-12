using UnityEngine;

namespace LevelManager
{
    [RequireComponent(typeof(LevelLoader))]
    public class WinSceneManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<LevelLoader>().LoadNextLevel("MenuScene");
            }
        }
    }
}