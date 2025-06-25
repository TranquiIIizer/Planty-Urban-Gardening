using Managers;
using UnityEngine;

public class MoneyAdder : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrencyManager.Instance.AddMoney(10);
        }
    }
}
