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
        [SerializeField] private TextMeshProUGUI _hp, _atk, _def;

        [SerializeField] private int _healthPoint;
        [SerializeField] private int _attack;
        [SerializeField] private int _defense;

        private void Start()
        {
            Debug.Assert(_tileCardName != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_hp != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_atk != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_def != null, "missing text component on [" + gameObject.name + "]");
            InitInfo();
        }

        private void Update() {
            DisplayInfo();
        }

        private void InitInfo() {
            _tileCardName.text = tileCardName;
            _healthPoint = cardInfo.healthPoints;
            _attack = cardInfo.attack;
            _defense = cardInfo.defense;
            DisplayInfo();
        }

        private void DisplayInfo() {
            _hp.text = _healthPoint.ToString();
            _atk.text = _attack.ToString();
            _def.text = _defense.ToString();
        }
    }
}
