using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource producedResource;
    [SerializeField] private float productionTime = 3f;
    [SerializeField] private Button productionButton;
    [SerializeField] private Slider progressSlider;

    private ResourceBank _resourceBank;
    private bool _isProducing;

    private void Start()
    {
        _resourceBank = FindObjectOfType<ResourceBank>();
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

        float timer = 0f;

        while (timer < productionTime)
        {
            timer += Time.deltaTime;
            progressSlider.value = timer / productionTime;
            yield return null;
        }

        _resourceBank.ChangeResource(producedResource, 1);

        _isProducing = false;
        productionButton.interactable = true;
        progressSlider.value = 0f;
    }
}