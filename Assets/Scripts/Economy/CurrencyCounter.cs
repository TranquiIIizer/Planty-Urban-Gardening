using System;
using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CurrencyCounter : MonoBehaviour
{
    private TextMeshProUGUI _currentMoneyText;

    private void Awake()
    {
        CurrencyManager.OnMoneyChanged += AddMoney;
        _currentMoneyText = GetComponent<TextMeshProUGUI>();
    }

    private void OnDestroy() => CurrencyManager.OnMoneyChanged -= AddMoney;

    private void AddMoney(int  amount)
    {
        StopAllCoroutines();
        StartCoroutine(CounterValueChange(amount));
    }

    IEnumerator CounterValueChange(int incrementAmount)
    {
        float elapsedTime = 0f;
        float duration = 1f;

        int startValue = CurrencyManager.Instance.GetCurrentMoney() - incrementAmount;
        int targetValue = CurrencyManager.Instance.GetCurrentMoney();
        Debug.Log(targetValue);

        while (elapsedTime < duration)
        {
            elapsedTime += (float)startValue / targetValue + Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            int currentDisplayValue = (int)Mathf.Lerp(startValue, targetValue, t);
            _currentMoneyText.text = currentDisplayValue.ToString();
            yield return null;
        }
        
        _currentMoneyText.text = CurrencyManager.Instance.GetCurrentMoney().ToString();
    }
}
