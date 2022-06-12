using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Components.Grid
{
    public class TileCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tileCardName;

        public string tileCardName;

        private void Start()
        {
            Debug.Assert(_tileCardName != null, "missing text component on [" + gameObject.name + "]");
            _tileCardName.text = tileCardName;
        }
    }
}
