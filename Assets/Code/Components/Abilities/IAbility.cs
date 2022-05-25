using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Abilities
{
    public interface IAbility
    {
        private void OnDiscard() { }
        private void OnPlayToField() { }
        private void OnActivate() { }
        private void OnceByTurn() { }
    }
}
