using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Abilities
{
    public class Ability : MonoBehaviour
    {
        public virtual void OnDiscard() { }
        public virtual void OnPlayToField() { }
        public virtual void OnActivate() { }
        public virtual void OnceByTurn() { }
    }
}
