namespace DefaultNamespace
{
    public class Ui
    {
        private ScoreView _scoreView;

        public Ui(ScoreView scoreView)
        {
            _scoreView = scoreView;
        }

        public void ShowScore()
        {
            _scoreView.gameObject.SetActive(true);
        }
    }
}