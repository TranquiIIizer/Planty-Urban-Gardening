using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolbarButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string buttonClassName;
    private Type _buttonType;
    
    public static event Action<Type> OnClick;

    private void Start()
    {
        _buttonType = Type.GetType(buttonClassName);

        CheckIfTypeHasIMenuInterface();
    }

    private void CheckIfTypeHasIMenuInterface()
    {
        if (typeof(IMenuTab).IsAssignableFrom(_buttonType))
            _buttonType = Type.GetType(buttonClassName);
        else
            Debug.LogError(buttonClassName + " does not have an interface IMenuTab!");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameTimeManager.Instance.StopTime();
        OnClick?.Invoke(_buttonType);
    }
}
