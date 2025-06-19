using System;
using Plants;
using UnityEngine;

namespace Managers
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        [SerializeField] private int _startingMoneyCount;
        [SerializeField] private int _currentMoney;
        
        public static Action<int> OnMoneyChanged;

        private void Start()
        {
            _currentMoney = _startingMoneyCount;
        }
        
        //  Zwięźlejsza wersja: public int GetCurrentMoney(){ return _currentMoney }
        public int GetCurrentMoney() => _currentMoney;

        public int GetStartingMoneyCount() => _startingMoneyCount;
        public void AddMoney(int amount)
        { 
            _currentMoney += amount;
            OnMoneyChanged?.Invoke(_currentMoney);
        }

        public void RemoveMoney(int amount)
        {
            _currentMoney -= amount;
            OnMoneyChanged?.Invoke(_currentMoney);
        } 
        //  Przykład przeciążania metod
        public void AddMoney(int amount, int times) => _currentMoney += amount * times;
        
        public void SubtractMoney(int amount, int times) => _currentMoney -= amount * times;
    }
}
