using UnityEngine;

namespace Game.Components {
    public interface IPlayer
    {
        int CountSelectedTiles { get; set; }
        int CountActiveTiles { get; set; }
    }
}
