using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class FieldGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _tile;
        [SerializeField] private int _tileNumber = 36;
        
        private void Awake()
        {
            Debug.Assert(_tile != null, "missing tile prefab on [" + gameObject.name + "]");    
        }

        private void Start()
        {
            for (int i = 0; i < _tileNumber; i++)
            {
                Instantiate(_tile, transform);
            }
        }
    }
}
