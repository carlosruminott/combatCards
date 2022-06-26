using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class Player : MonoBehaviour, IPlayer
    {
        public static IPlayer Instance {
            get {
                if(_instance == null) {
                    var auxGameObject = new GameObject("Player");
                    _instance = auxGameObject.AddComponent<Player>();
                }
                return _instance;
            }
        }
        private static IPlayer _instance;
        private int _countActiveTiles = 0;
        private int _countSelectedTiles = 0;

        public int CountSelectedTiles { get => _countSelectedTiles; set => _countSelectedTiles = value; }
        public int CountActiveTiles { get => _countActiveTiles; set => _countActiveTiles = value; }

        //private void Awake() => Instance = Instance ?? (Instance = this);
    }
}