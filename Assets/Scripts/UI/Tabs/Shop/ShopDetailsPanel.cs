using Plants;
using TMPro;
using UI.Tabs.Shop;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopDetailsPanel : MonoBehaviour
{
    private PlantScriptableObject _plant;
    [SerializeField] private TextMeshProUGUI plantSeedsName;
    [SerializeField] private TextMeshProUGUI timeToGrowText;
    [SerializeField] private TextMeshProUGUI seasonText;
    [SerializeField] private Image[] buffImages;
    [SerializeField] private Image[] debuffImages;
    [SerializeField] private TextMeshProUGUI seedPriceText;

    private void OnEnable() => ShopCardHandler.OnClick += UpdateDetailsUI;
    private void OnDisable() => ShopCardHandler.OnClick -= UpdateDetailsUI;


    private void UpdateDetailsUI(PlantScriptableObject plantData)
    {
        plantSeedsName.text = plantData.GetSeedsName();
        timeToGrowText.text = plantData.GetDaysToFullyGrown();
        seasonText.text = plantData.GetSeasonText();
        
        DisableImages();
        SetBuffDebuffSprites(plantData);
        
        seedPriceText.text = plantData.GetSeedPrice().ToString();
    }

    private void SetBuffDebuffSprites(PlantScriptableObject plantData)
    {
        for (int i = 0; i < plantData.GetBuffSprites().Length; i++)
        {
            buffImages[i].sprite = plantData.GetBuffSprites()[i];
            buffImages[i].enabled = true;
        }

        for (int i = 0; i < plantData.GetDebuffSprites().Length; i++)
        {
            debuffImages[i].sprite = plantData.GetDebuffSprites()[i];
            debuffImages[i].enabled = true;
        }
    }

    private void DisableImages()
    {
        foreach (Image img in buffImages) img.enabled = false;
        foreach (Image img in debuffImages) img.enabled = false;
    }
}
