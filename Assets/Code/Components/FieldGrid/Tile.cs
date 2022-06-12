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

        private TileCardView _tileCardScript;

        private void Awake()
        {
            EventDispatcher.SpawnOnTile.AddListener(SpawnTileCard);
        }

        private void Start()
        {
            Debug.Assert(_numberTile != null, "missing text component on [" + gameObject.name + "]");
            Debug.Assert(_tileCard != null, "missing text component on [" + gameObject.name + "]");
            _numberTile.text = transform.name;
            _tileCardScript = _tileCard.GetComponent<TileCardView>();
        }

        public void SpawnTileCard(BaseCard cardInfo)
        {
            _tileCardScript.tileCardName = cardInfo.cardName;
            var tileCard = Instantiate(_tileCard, transform);

        }
    }
}
