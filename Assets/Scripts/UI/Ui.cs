namespace DefaultNamespace
{
    public class Ui
    {
        private ScoreView _scoreView;
        private ShopView _shopView;

        public Ui(ScoreView scoreView, ShopView shopView)
        {
            _scoreView = scoreView;
            _shopView = shopView;
        }

        public void ShowScore()
        {
            _scoreView.gameObject.SetActive(true);
        }
    }
}