using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Logic;

namespace Game.Components.Grid
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberTile;
        [SerializeField] private GameObject _tileCard;
        [SerializeField] private GameObject _tileCardButton;
        [SerializeField] private bool _isTileActive = false;

        public bool isTileActive 
        { 
            get { return _isTileActive; } 
        }

        private TileCardView _tileCardScript;

        private void Awake()
        {
            EventDispatcher.SendInfoCard.AddListener(GetInfoCard);
        }

        private void Start()
        {
            Debug.Assert(_numberTile != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_tileCard != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_tileCardButton != null, "missing text component on [" + gameObject.name + "]");
            _numberTile.text = transform.name;
            _tileCardScript = _tileCard.GetComponent<TileCardView>();
        }

        private void GetInfoCard(BaseCard cardInfo)
        {
            _tileCardScript.tileCardName = cardInfo.cardName;
        }

        public void SpawnTileCard()
        {
            _isTileActive = true;
            Instantiate(_tileCard, _tileCardButton.transform);
            EventDispatcher.TileSapwned?.Invoke();
        }
    }
}
