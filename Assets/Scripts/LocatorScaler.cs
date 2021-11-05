using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [ExecuteInEditMode]
    public class LocatorScaler : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float radius = 5f;

        private void Update()
        {
            transform.localScale = new Vector3(radius, radius, 1);
        }
    }

