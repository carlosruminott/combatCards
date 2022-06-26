using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    [CreateAssetMenu(fileName = "UserData", menuName = "Game Data/New User Data", order = 1)]
    public class UserData : ScriptableObject
    {
        public int countActiveTiles = 0;
        public int countSelectedTiles = 0;
    }
}
