using Game.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Grid
{
    public class FieldGrid : MonoBehaviour
    {
        [SerializeField] private GameObject _tile;
        [SerializeField] private int _tileNumber = 36;
        [SerializeField] private List<GameObject> _tiles;

        private int _firstTileFile = 30;
        private int _lastTileFile = 35;

        private int _countActiveTiles;

        public List<GameObject> tileList {get { return _tiles; }}
        public int countActiveTiles {get { return _countActiveTiles; }}
        public List<int> activeTiles = new List<int>();

        private void Awake()
        {
            Debug.Assert(_tile != null, "missing tile prefab on [" + gameObject.name + "]");
            EventDispatcher.SendInfoCard.AddListener(ActiveTilesToSpawnCard);
            EventDispatcher.TileSapwned.AddListener(DeactiveTilesButtons);
            EventDispatcher.SendInt.AddListener(ActiveTileButton);
            EventDispatcher.DiscardTile.AddListener(DiscardTiles);
            EventDispatcher.GetActiveTileInField.AddListener(SetActiveTileList);
        }

        private void Start()
        {
            for (int i = 0; i < _tileNumber; i++)
            {
                var spawnedTile = Instantiate(_tile, transform);
                spawnedTile.name = $"{i}";
                _tiles.Add(spawnedTile);
            }
        }

        private void ActiveTilesToSpawnCard(BaseCard cardInfo)
        {
            for (int i = _firstTileFile; i <= _lastTileFile; i++)
            {
                if(_tiles[i].GetComponent<Tile>().isTileActive == false)
                {
                    _tiles[i].transform.Find("TileButton").gameObject.SetActive(true);
                }
            }
        }

        private void DeactiveTilesButtons()
        {
            _countActiveTiles = 0;
            foreach (var tile in _tiles)
            {
                if (tile.GetComponent<Tile>().isTileActive == false )
                {
                    tile.transform.Find("TileButton").gameObject.SetActive(false);
                }else {
                    _countActiveTiles++;
                }
            }
            EventDispatcher.GetCountActiveTilesInField?.Invoke(_countActiveTiles);
        }

        private void ActiveTileButton(int tilePosition)
        {
            //if (tilePosition < _firstTileFile || tilePosition > _lastTileFile) return;
            _tiles[tilePosition].transform.Find("TileButton").gameObject.SetActive(true);
        }

        private void SetActiveTileList(int tileNumber) {
            activeTiles.Add(tileNumber);
        }

        private void DiscardTiles()
        {
            foreach (var tile in _tiles)
            {
                //Debug.Log("Tile selected: "+tile.GetComponent<Tile>().isSelected);
                var tileScript = tile.GetComponent<Tile>();
                if (tileScript.isSelected == true)
                {
                    var tileButton = tile.transform.Find("TileButton").gameObject;
                    var childOfButtonText = tileButton.transform.GetChild(0).gameObject;
                    var childOfButton = tileButton.transform.GetChild(1);
                    var cardInfo = childOfButton.GetComponent<TileCardView>().CardInfo;
                    childOfButtonText.SetActive(true);
                    tileButton.SetActive(false);
                    tileScript.isTileActive = false;
                    tileScript.isSelected = false;
                    Destroy(childOfButton.gameObject);
                    EventDispatcher.Discard?.Invoke(cardInfo);
                    activeTiles.Remove(Int32.Parse(tile.gameObject.name));
                }
            }
        }
    }
}
