namespace Assets.Scripts.Managers
{
    using TMPro;
    using UnityEngine;

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreTMP;

        public int CurrentScore { get; private set;  }


        public void IncrementScore()
        {
            CurrentScore++;
            UpdateScoreTMP();
        }

        public void DecrementScore()
        {
            CurrentScore--;
            SetScoreToZeroWhenLessThanZero();
            UpdateScoreTMP();
        }

        private void SetScoreToZeroWhenLessThanZero()
        {
            if (CurrentScore < 0)
            {
                ResetScore();
            }
        }

        private void ResetScore()
        {
            CurrentScore = 0;
            UpdateScoreTMP();
        }

        private void UpdateScoreTMP()
        {
            _scoreTMP.text = CurrentScore.ToString();
            Debug.Log(_scoreTMP.text);
        }

    }
}