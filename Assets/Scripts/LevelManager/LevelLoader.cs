using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Enums;

namespace LevelManager
{
    public class LevelLoader : MonoBehaviour
    {
        //public Animator transition;
        //public float transitionTime = 1f;

        public static Vector2Int GameSize;
        public static Difficulty GameDifficulty;

        public void LoadNextLevel(string nextScene, Vector2Int size, Difficulty difficulty)
        {
            GameSize = size;
            GameDifficulty = difficulty;
            LoadNextLevel(nextScene);
        }
        
        public void LoadNextLevel(string nextScene)
        {
            SceneManager.LoadScene(nextScene);

            /*StartCoroutine(
                LoadLevel(nextScene)
                );*/
        }

        /*IEnumerator LoadLevel(String nextScene)
        {
            // Play animation
            
            //transition.SetTrigger("Start");
            
            // Wait

            //yield return new WaitForSeconds(transitionTime);

            //Load Sceen
            SceneManager.LoadScene(nextScene);
        }*/
    }
}