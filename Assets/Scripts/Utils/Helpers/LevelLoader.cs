using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Enums;

namespace Utils.Helpers
{
    public class LevelLoader : MonoBehaviour
    {
        //public Animator transition;
        //public float transitionTime = 1f;

        public static Vector2Int GameSize;
        public static Difficulty GameDifficulty;

        protected void LoadNextLevel(string nextScene, Vector2Int size, Difficulty difficulty)
        {
            GameSize = size;
            GameDifficulty = difficulty;
            LoadNextLevel(nextScene);
        }
        
        protected void LoadNextLevel(string nextScene)
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