using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Abilities
{
    public class Ability1 : Ability
    {

        public override void PlayAbility()
        {
            OnActivate();
        }

        public override void OnActivate()
        {
            Debug.Log("hola!");
        }

    }
}
