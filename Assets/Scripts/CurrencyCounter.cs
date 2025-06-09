using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CurrencyCounter : MonoBehaviour
{
    private int _currentMoney;
    private TextMeshProUGUI _currentMoneyText;
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.UI.UIClick.Enable();
        _playerInputActions.UI.UIClick.performed += AddMoney;

        _currentMoneyText = GetComponent<TextMeshProUGUI>();
    }

    private void AddMoney(InputAction.CallbackContext ctx)
    {
        Debug.Log("AddMoney");
        StopAllCoroutines();
        StartCoroutine(CounterValueChange(100));
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
