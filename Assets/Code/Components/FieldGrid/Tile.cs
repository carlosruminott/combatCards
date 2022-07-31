
using System;
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
        [SerializeField] private GameObject _tileCardButtonText;
        [SerializeField] private bool _isTileActive = false;

        // private int _tilePosition;

        public bool isSelected = false;
        public bool isTileActive { get { return _isTileActive; } set { _isTileActive = value; } }

        // public int tilePosition { get { return _tilePosition; } }

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
            Debug.Assert(_tileCardButtonText != null, "missing text component on [" + gameObject.name + "]");
            _numberTile.text = transform.name;
            _tileCardScript = _tileCard.GetComponent<TileCardView>();
        }

        private void GetInfoCard(BaseCard cardInfo)
        {
            _tileCardScript.SetCardInfo = cardInfo;
            _tileCardScript.tileCardName = cardInfo.cardName;
        }

        public void SpawnTileCard()
        {
            if (_isTileActive) return;
            _isTileActive = true;
            Instantiate(_tileCard, _tileCardButton.transform);
            _tileCardButtonText.SetActive(false);
            EventDispatcher.GetActiveTileInField?.Invoke(Int32.Parse(transform.name));
            EventDispatcher.TileSapwned?.Invoke();
            EventDispatcher.ZoomOut?.Invoke();
        }
    }
}
