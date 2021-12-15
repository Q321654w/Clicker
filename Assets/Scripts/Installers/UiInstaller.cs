using UnityEngine;

namespace DefaultNamespace
{
    public class UiInstaller : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreViewPrefab;
        [SerializeField] private Canvas _canvasPrefab;
        [SerializeField] private CustomButton _clickButtonPrefab;
        [SerializeField] private ShopView _shopViewPrefab;
        [SerializeField] private NumberFormatter _numberFormatter;

        public CustomButton ClickButton { get; private set; }

        public Ui Install(Wallet wallet, Shop shop, ProductDataBase dataBase)
        {
            return CreateUi(wallet, shop, dataBase);
        }

        private Ui CreateUi(Wallet wallet, Shop shop, ProductDataBase dataBase)
        {
            var canvas = Instantiate(_canvasPrefab);
            var scoreView = Instantiate(_scoreViewPrefab, canvas.transform);
            scoreView.Initialize(wallet, _numberFormatter);

            ClickButton = Instantiate(_clickButtonPrefab, canvas.transform);

            var shopView = Instantiate(_shopViewPrefab, canvas.transform);
            shopView.Initialize(dataBase.Products, shop);

            return new Ui(scoreView, shopView);
        }
    }
}