using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Grid
{
    public class TileCardController : MonoBehaviour
    {
        private TileCardView _tileCardView;
        private void Start() {
            _tileCardView = GetComponent<TileCardView>();
        }

        public void Heal(int h) {
            var hp = _tileCardView.healthPoint;
            _tileCardView.healthPoint = hp + h;
        }
    }
}
