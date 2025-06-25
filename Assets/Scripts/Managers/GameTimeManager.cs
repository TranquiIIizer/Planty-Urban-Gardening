using System;
using System.Collections;
using UnityEngine;

public class GameTimeManager : Singleton<GameTimeManager>
{
    [SerializeField] private int timeCount;
    Coroutine _inGameTimeCoroutine;

    public static Action TimeTickEvent;

    private void Start()
    {
        StartTime();
    }

    public void StartTime()
    {
        if (_inGameTimeCoroutine == null)
            _inGameTimeCoroutine = StartCoroutine(UpdateTime());
    }

    public void StopTime()
    {
        if (_inGameTimeCoroutine != null)
        {
            StopCoroutine(_inGameTimeCoroutine);
            _inGameTimeCoroutine = null;
        }
    }
    
    IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TimeTickEvent?.Invoke();
            timeCount++;
        }
    }
}
