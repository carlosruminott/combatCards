using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Abilities
{
    public class Ability : MonoBehaviour
    {
        private bool _played = false;
        public bool WasPlayed {get => _played; set => _played = value; }

        public virtual void PlayAbility() { }
        public virtual void OnActivate() { }
        public virtual void OnPlayToField() { }
        public virtual void OnAttachToCard() { }
        public virtual void OnceByTurn() { }
        public virtual void OnDiscard() { }
    }
}
