using System;
using Core;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private GameResource resourceType;
        [SerializeField] private TextMeshProUGUI textComponent;
        [SerializeField] private ResourceBank resourceBank;
        private ObservableInt _resourceValue;

        private void Start()
        {
            resourceBank = FindObjectOfType<ResourceBank>();
            _resourceValue = resourceBank.GetResource(resourceType);
            
            _resourceValue.OnValueChanged += UpdateText;
            
            UpdateText(_resourceValue.Value);
        }

        private void UpdateText(int value)
        {
            textComponent.text = $"{resourceType.ToString()}: {value}";
        }
    }
}