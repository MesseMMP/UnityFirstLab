using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ResourceBank : MonoBehaviour
    {
        private readonly Dictionary<GameResource, ObservableInt> _resourceDictionary = new ();

        private void Awake()
        {
            foreach (GameResource resource in Enum.GetValues(typeof(GameResource)))
            {
                _resourceDictionary.Add(resource, new ObservableInt(0));
            }
        }

        public void ChangeResource(GameResource r, int v)
        {
            _resourceDictionary[r].Value += v;
        }

        public ObservableInt GetResource(GameResource r)
        {
            return _resourceDictionary[r];
        }
    }
}