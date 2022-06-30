using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Components.Grid
{
    public class TileCardView : MonoBehaviour
    {
        public string tileCardName;
        public BaseCard cardInfo;

        [SerializeField] private TextMeshProUGUI _tileCardName;
        [SerializeField] private TextMeshProUGUI _hp;

        private void Start()
        {
            Debug.Assert(_tileCardName != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_hp != null, "missing text component on [" + gameObject.name + "]");
            _tileCardName.text = tileCardName;
            _hp.text = cardInfo.healthPoints.ToString();
        }
    }
}
