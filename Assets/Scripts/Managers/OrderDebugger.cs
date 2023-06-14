using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class OrderDebugger : MonoBehaviour
    {
        public void ShowSuccess()
        {
            Debug.Log("The Burger is Correct");
        }

        public void ShowFail()
        {
            Debug.Log("The Burger is a Failure");
        }

        public void StopGame()
        {
            Time.timeScale = 0;
        }
    }
}