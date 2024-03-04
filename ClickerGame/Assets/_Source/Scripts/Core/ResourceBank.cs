using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ResourceBank : MonoBehaviour
    {
        private Dictionary<GameResource, ObservableInt> _resources = new ();

        void Start()
        {
            foreach (GameResource resource in Enum.GetValues(typeof(GameResource)))
            {
                _resources.Add(resource, new ObservableInt(0));
            }
        }

        public void ChangeResource(GameResource r, int v)
        {
            _resources[r].Value += v;
        }

        public ObservableInt GetResource(GameResource r)
        {
            return _resources[r];
        }
    }
}