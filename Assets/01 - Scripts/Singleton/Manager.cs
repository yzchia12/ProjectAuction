using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBid.Manager
{
    public abstract class Manager<T> : MonoBehaviour where T : Manager<T>
    {
        public static T Instance { get; private set; }

        

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("A instance already exists at: " + gameObject.name);
                Destroy(this.gameObject); //Or GameObject as appropriate
                return;
            }

            Instance = this as T;
        }
    }
}