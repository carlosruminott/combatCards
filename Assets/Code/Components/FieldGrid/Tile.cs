using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Components.Grid
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberTile;

        private void Start()
        {
            Debug.Assert(_numberTile != null, "missing text component on [" + gameObject.name + "]");
            _numberTile.text = transform.name;
        }
    }
}
