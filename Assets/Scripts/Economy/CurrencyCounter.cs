using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CurrencyCounter : MonoBehaviour
{
    private int _currentMoney;
    private TextMeshProUGUI _currentMoneyText;

    private void Awake()
    {
        CurrencyManager.OnMoneyChanged += AddMoney;
        _currentMoneyText = GetComponent<TextMeshProUGUI>();
    }

    private void AddMoney(int  amount)
    {
        StopAllCoroutines();
        StartCoroutine(CounterValueChange(amount));
    }

    IEnumerator CounterValueChange(int incrementAmount)
    {
        float elapsedTime = 0f;
        float duration = 1f;
        
        int startValue = _currentMoney;
        int targetValue = startValue + incrementAmount;
        
        _currentMoney += incrementAmount;
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            int currentDisplayValue = (int)Mathf.Lerp(startValue, targetValue, t);
            _currentMoneyText.text = currentDisplayValue.ToString();
            yield return null;
        }
        
        _currentMoneyText.text = _currentMoney.ToString();
    }
    
    private void Start()
    {
        _currentMoney = CurrencyManager.Instance.GetStartingMoneyCount();
    }
}
