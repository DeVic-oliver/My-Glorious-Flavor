namespace Assets.Scripts.Managers
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneManagerHandler : MonoBehaviour
    {
        private Coroutine _currentSceneCoroutine;
        
        public void RestartScene()
        {
            if(_currentSceneCoroutine != null )
            {
                _currentSceneCoroutine = StartCoroutine(ReloadSceneCoroutine());
            }
        }

        private IEnumerator ReloadSceneCoroutine()
        {
            float secondsToWait = 1f;
            yield return new WaitForSeconds(secondsToWait);
         
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneID);
        }

    }
}