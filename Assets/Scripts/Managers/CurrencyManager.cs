using UnityEngine;
using TMPro;

namespace Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        private int _currentMoney;
        [SerializeField] private TextMeshProUGUI moneyCounter;

        private void Start()
        {

        }
        
        //  Zwięźlejsza wersja: public int GetCurrentMoney(){ return _currentMoney }
        public int GetCurrentMoney() => _currentMoney;

        public void AddMoney(int amount) => _currentMoney += amount;
        //  Przykład przeciążania metod
        public void AddMoney(int amount, int times) => _currentMoney += amount * times;
        
        public void RemoveMoney(int amount, int times) => _currentMoney -= amount * times;
    }
}
