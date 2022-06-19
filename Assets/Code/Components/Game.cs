using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        private void Awake() => Instance = this; 
    }
}
