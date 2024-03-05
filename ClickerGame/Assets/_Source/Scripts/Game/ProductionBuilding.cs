using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource producedResource;
    [SerializeField] private float baseProductionTime = 3f;
    [SerializeField] private Button productionButton;
    [SerializeField] private Slider progressSlider;

    [SerializeField] private ResourceBank resourceBank;
    private bool _isProducing;

    private void Start()
    {
        productionButton.onClick.AddListener(StartProduction);
    }

    private void StartProduction()
    {
        if (!_isProducing)
        {
            StartCoroutine(ProduceResource());
        }
    }

    private IEnumerator ProduceResource()
    {
        _isProducing = true;
        productionButton.interactable = false;

        ObservableInt prodLvl = resourceBank.GetResource(producedResource);

        float prodLvlMultiplier = 1 - (prodLvl.Value / 100f);

        float productionTime = baseProductionTime * prodLvlMultiplier;

        float timer = 0f;

        while (timer < productionTime)
        {
            timer += Time.deltaTime;
            progressSlider.value = timer / productionTime;
            yield return null;
        }

        resourceBank.ChangeResource(producedResource, 1);

        _isProducing = false;
        productionButton.interactable = true;
        progressSlider.value = 0f;
    }
}