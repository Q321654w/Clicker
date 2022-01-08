using UnityEngine;

namespace DefaultNamespace
{
    public class Ui : ICleanUp
    {
        private Canvas _canvas;
        private ScoreView _scoreView;
        private ShopView _shopView;

        public Canvas Canvas => _canvas;

        public Ui(ScoreView scoreView, ShopView shopView, Canvas canvas)
        {
            _scoreView = scoreView;
            _shopView = shopView;
            _canvas = canvas;
        }

        public void ShowShop()
        {
            _shopView.gameObject.SetActive(true);
        }

        public void HideShop()
        {
            _shopView.gameObject.SetActive(false);
        }

        public void ShowScore()
        {
            _scoreView.gameObject.SetActive(true);
        }

        public void HideScore()
        {
            _scoreView.gameObject.SetActive(false);
        }

        public void CleanUp()
        {
            _scoreView.CleanUp();
            _shopView.CleanUp();
        }
    }
}