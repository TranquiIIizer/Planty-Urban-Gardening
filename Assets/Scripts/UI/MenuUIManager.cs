using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class MenuUIManager : Singleton<MenuUIManager>
    {
        [SerializeField] private GameObject menuContainer;
        
        private List<IMenuTab> _menuTabs = new();
        private List<MonoBehaviour> _menuTabTypes = new();

        private void Start()
        {
            _menuTabs.AddRange(GetComponentsInChildren<IMenuTab>(true));
            GetTabTypes();
            menuContainer.SetActive(false);
        }

        private void OnEnable()
        {
            ToolbarButton.OnClick += ShowMenuTab;
        }

        private void OnDisable()
        {
            ToolbarButton.OnClick -= ShowMenuTab;
        }


        public void OnCloseButtonClicked()
        {
            GameTimeManager.Instance.StartTime();
            menuContainer.SetActive(false);
        }
        
        private void GetTabTypes()
        {
            foreach (var menuTab in _menuTabs)
            {
                if (menuTab is MonoBehaviour monoBehaviour)
                    _menuTabTypes.Add(monoBehaviour);
            }
        }
        private void ShowMenuTab(Type type)
        {
            foreach (MonoBehaviour menuTab in _menuTabTypes)
            {
                if (menuTab.GetType() == type)
                {
                    menuTab.gameObject.SetActive(true);
                    menuContainer.SetActive(true);
                }
                else
                    menuTab.gameObject.SetActive(false);
                    
            }
        }
    }
}
