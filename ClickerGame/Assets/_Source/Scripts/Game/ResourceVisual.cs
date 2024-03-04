using Core;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private GameResource resourceType;
        [SerializeField] private TextMeshProUGUI textComponent;
        private ObservableInt _resourceValue;
        private ResourceBank _resourceBank;

        private void Start()
        {
            _resourceValue = _resourceBank.GetResource(resourceType);
            
            _resourceValue.OnValueChanged += UpdateText;
            
            UpdateText(_resourceValue.Value);
        }

        private void UpdateText(int value)
        {
            textComponent.text = $"{resourceType.ToString()}: {value}";
        }
    }
}