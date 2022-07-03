using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Components.Grid
{
    public class TileCardView : MonoBehaviour
    {
        public string tileCardName;
        public int healthPoint;
        public int attack;
        public int defense;

        public BaseCard CardInfo {get { return _cardInfo; }}
        public BaseCard SetCardInfo {set { _cardInfo = value; }}

        [SerializeField] private BaseCard _cardInfo;
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private TextMeshProUGUI _tileCardName;
        [SerializeField] private TextMeshProUGUI _hp, _atk, _def;

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
            healthPoint = _cardInfo.healthPoints;
            _maxHealthPoint = _cardInfo.healthPoints;
            attack = _cardInfo.attack;
            defense = _cardInfo.defense;
            DisplayInfo();
        }

        private void DisplayInfo() {
            _hp.text = healthPoint.ToString();
            _atk.text = attack.ToString();
            _def.text = defense.ToString();
        }
    }
}
