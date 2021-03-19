using System;
using UnityEngine;

    public class LiveTime : MonoBehaviour
    {
        [SerializeField]
        private float lifetime = 2f;
        private void Start()
        {
            Destroy(gameObject, lifetime);
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
        
    }
