using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class IA : MonoBehaviour
    {
        public static IA Instance;
        public int countActiveTiles = 0;

        private void Awake() => Instance = this;
    }
}