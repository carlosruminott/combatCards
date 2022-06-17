using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Grid
{
    public class TileController : MonoBehaviour
    {
        private Tile _tileScript;
        //private FieldGrid _gridScript;
        private int _tilePosition;
        private int _tilesRowNum = 6;
        private List<int> _movePosibilities = new List<int>();

        private void Start() {
            _tilePosition = int.Parse(gameObject.name);
            _tileScript = GetComponent<Tile>();
            //_gridScript = GetComponentInParent<FieldGrid>();
        }        

        public void ShowPathToMove() {
            if(_tileScript.isTileActive == false) return;
            int blockPosibility = _tilePosition - _tilesRowNum;
            _movePosibilities.Add(blockPosibility);
            _movePosibilities.Add(blockPosibility - _tilesRowNum);
        }

    }
}
