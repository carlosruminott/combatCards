using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components.Abilities {
    public class Potion : Ability
    {
        public override void OnActivate()
        {
            Debug.Log("Cura 2 puntos de 1 jugador");
            //TODO:
            //seleccionar carta en campo y quitarle 2 puntos de daño
        }
    }
}
