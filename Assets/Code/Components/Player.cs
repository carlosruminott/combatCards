using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        public int countActiveTiles = 0;
        public int countSelectedTiles = 0;

        private void Awake() => Instance = this;
    }
}