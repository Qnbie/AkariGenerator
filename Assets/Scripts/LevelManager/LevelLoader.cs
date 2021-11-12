using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Enums;

namespace LevelManager
{
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;
        public float transitionTime = 1f;

        public static Vector2Int GameSize;
        public static Difficulty GameDifficulty;

        public void LoadNextLevel(String nextScene, Vector2Int size, Difficulty difficulty)
        {
            GameSize = size;
            GameDifficulty = difficulty;
            LoadNextLevel(nextScene);
        }
        
        public void LoadNextLevel(String nextScene)
        {
            StartCoroutine(
                LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)
                );
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            // Play animation
            
            transition.SetTrigger("Start");
            
            // Wait

            yield return new WaitForSeconds(transitionTime);

            //Load Sceen
            SceneManager.LoadScene(levelIndex);
        }
    }
}