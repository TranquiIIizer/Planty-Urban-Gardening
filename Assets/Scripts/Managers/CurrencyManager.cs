using System;
using UnityEngine;

namespace Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        [SerializeField] private int _startingMoneyCount;
        private int _currentMoney;
        
        public static Action<int> OnMoneyChanged;

        private void Start()
        {
            OnMoneyChanged?.Invoke(_startingMoneyCount);
            _currentMoney = _startingMoneyCount;
        }
        
        //  Zwięźlejsza wersja: public int GetCurrentMoney(){ return _currentMoney }
        public int GetCurrentMoney() => _currentMoney;

        public int GetStartingMoneyCount() => _startingMoneyCount;
        public void AddMoney(int amount) => _currentMoney += amount;
        //  Przykład przeciążania metod
        public void AddMoney(int amount, int times) => _currentMoney += amount * times;
        
        public void RemoveMoney(int amount, int times) => _currentMoney -= amount * times;
    }
}
