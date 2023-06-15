namespace Assets.Scripts.Components
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameOver : MonoBehaviour
    {
        public UnityEvent OnGameOver;

        public void FireEventsFinishMessageDisappear()
        {
            OnGameOver?.Invoke();
        }

    }
}