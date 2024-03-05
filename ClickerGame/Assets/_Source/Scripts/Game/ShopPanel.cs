using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ShopPanel : MonoBehaviour
    {
        public ResourceBank resourceBank;

        [SerializeField] private Button humansUpgradeButton;
        [SerializeField] private Button foodUpgradeButton;
        [SerializeField] private Button woodUpgradeButton;
        [SerializeField] private Button stoneUpgradeButton;
        [SerializeField] private Button goldUpgradeButton;

        private void Start()
        {
            humansUpgradeButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.HumansProdLvl));
            foodUpgradeButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.FoodProdLvl));
            woodUpgradeButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.WoodProdLvl));
            stoneUpgradeButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.StoneProdLvl));
            goldUpgradeButton.onClick.AddListener(() => UpgradeProductionLevel(GameResource.GoldProdLvl));
        }

        private void UpgradeProductionLevel(GameResource prodLvlResource)
        {
            resourceBank.ChangeResource(prodLvlResource, 1);
            Debug.Log($"{prodLvlResource} upgraded to {resourceBank.GetResource(prodLvlResource).Value}");
        }

    } 
}