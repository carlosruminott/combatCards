using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;

namespace Game.Components.Grid
{
    public class TileController : MonoBehaviour
    {
        private Tile _tileScript;
        private FieldGrid _gridScript;
        private int _tilePosition;
        private int _tilesRowNum = 6;
        private bool _isTimeToMove = true;
        private List<int> _movePosibilities = new List<int>();
        private List<int> _hidePosibilities = new List<int>();
        private List<int> _tileShowPath = new List<int>();

        private void Awake() {
            EventDispatcher.PlayCardToField.AddListener(canMove);
            EventDispatcher.PlayCardToFieldWithSacrifice.AddListener(DontMove);
        }

        private void Start() {
            _tilePosition = int.Parse(gameObject.name);
            _tileScript = GetComponent<Tile>();
            _gridScript = GetComponentInParent<FieldGrid>();
        } 

        private void canMove() {
            _isTimeToMove = true;
        }

        private void DontMove() {
            _isTimeToMove = false;
        }

        public void TimeToSelectTiles() {
            if(_isTimeToMove) return;
            if(_tileScript.isSelected) return;
            _tileScript.isSelected = true;
            Player.Instance.CountSelectedTiles++;
        }       

        public void ShowOrHidePathToMove() {
            if(_tileScript.isTileActive == false) return;
            if(_isTimeToMove == false) return;
            EventDispatcher.TileSapwned?.Invoke(); // deactivated tile buttons
            int blockPosibility = _tilePosition - _tilesRowNum;
            if(_tileShowPath.Contains(_tilePosition) == false) {
                _tileShowPath.Add(_tilePosition);
                _movePosibilities.Clear();
                _movePosibilities.Add(blockPosibility);
                _movePosibilities.Add(blockPosibility - _tilesRowNum);
                foreach (var item in _movePosibilities)
                {
                    //Debug.Log(item);
                    EventDispatcher.SendInt?.Invoke(item);
                }
            }else {
                _tileShowPath.Clear();
            }
        }

        public void HidePastRows() {
            int row = DefineRowPosition(_tilePosition);       
            if(row == 1) return;     
            int blockToHide = _tilePosition;
            for (int i = 1; i < row; i++)
            {
                blockToHide += _tilesRowNum;
                _gridScript.tileList[blockToHide].transform.Find("TileButton").gameObject.SetActive(false);
            }
        }

        private int DefineRowPosition(int position) {
            if(30 <= position && position <= 35) {
                return 1;
            }
            if(24 <= position && position <= 29) {
                return 2;
            }
            if(18 <= position && position <= 23) {
                return 3;
            }
            if(12 <= position && position <= 17) {
                return 4;
            }
            if(6 <= position && position <= 11) {
                return 5;
            }
            return 6;
        }

    }
}
