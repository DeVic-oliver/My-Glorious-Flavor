namespace Assets.Scripts.Managers
{
    using TMPro;
    using UnityEngine;
    using Assets.Scripts.Services;
    using UnityEngine.Events;

    public class Timer : MonoBehaviour
    {
        public UnityEvent OnTimeEnds;

        [SerializeField] private int _maxTimeInSeconds = 120;
        [SerializeField] private TextMeshProUGUI _timerTMP;

        private float _currentTime;
        private bool _shouldCount;

 
        void Start()
        {
            ResetTimer();
        }

        public void ResetTimer()
        {
            _currentTime = _maxTimeInSeconds;
            UpdateTimerTMP(_currentTime);
        }

        public void StartTimer()
        {
            _shouldCount = true;
        }

        private void Update()
        {
            CountDown();
            FireEventsWhenTimeReachesZeroThenStopCounting();
        }

        private void CountDown()
        {
            if (ShouldCount())
            {
                _currentTime -= Time.deltaTime;
                UpdateTimerTMP(_currentTime);
            }
        }

        private bool ShouldCount()
        {
            return (_shouldCount && _currentTime > 0);
        }

        private void UpdateTimerTMP(float value)
        {
            _timerTMP.text = TimeFormatter.GetTimeFormated(value);
        }

        private void FireEventsWhenTimeReachesZeroThenStopCounting()
        {
            if(_currentTime <= 0)
            {
                OnTimeEnds?.Invoke();
                _shouldCount = false;
            }
        }
    }
}