using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopPanelAnimationController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button _shopOpenButton;
    private Animator _shopPanelAnimator;
    private bool _pointerOn;
    

    private void Start()
    {
        _shopOpenButton = GetComponentInChildren<Button>();
        _shopPanelAnimator = GetComponent<Animator>();
        _pointerOn = false;
    }

    public void OpenShopPanel()
    {
        _shopPanelAnimator.SetBool("IsOpened", true);
        //_shopOpenButton.gameObject.SetActive(false);
    }

    private IEnumerator CanClosePanel()
    {
        bool running = true;
        yield return new WaitForSeconds(0.5f);
        if (!_pointerOn)
        {
            _shopPanelAnimator.SetBool("IsOpened", false);
        }
    }

    public void ShowButton() => _shopOpenButton.gameObject.SetActive(true);
    
    public void OnPointerExit(PointerEventData eventData)
    {
        _pointerOn = false;
        StartCoroutine(CanClosePanel());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointerOn = true;
    }
}
