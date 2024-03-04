using Core;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceBank resourceBank;

        private void Awake()
        {
            resourceBank.ChangeResource(GameResource.Humans, 10);
            resourceBank.ChangeResource(GameResource.Food, 5);
            resourceBank.ChangeResource(GameResource.Wood, 5);
        }
    }
}