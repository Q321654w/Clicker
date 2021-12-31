using DefaultNamespace.ProductProviders;
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

        public Ui Install(Wallet wallet, Shop shop, ProductProvider productProvider, IncomeProvider incomeProvider)
        {
            var canvas = Instantiate(_canvasPrefab);
            var scoreView = Instantiate(_scoreViewPrefab, canvas.transform);
            scoreView.Initialize(wallet, _numberFormatter, incomeProvider);

            ClickButton = Instantiate(_clickButtonPrefab, canvas.transform);

            var shopView = Instantiate(_shopViewPrefab, canvas.transform);
            shopView.Initialize(productProvider.GetAllProducts(), shop, _numberFormatter);

            return new Ui(scoreView, shopView);
        }
    }
}