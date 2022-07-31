using System.Collections;
using System.Collections.Generic;
using Game.Logic;
using Game.Components.Grid;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Components.Abilities {
    public class Potion : Ability
    {
        private int _healPoints = 2;
        private bool _active = false;

        public bool IsActive {get {return _active;}}

        public override void OnActivate()
        {
            Debug.Log("Cura 2 puntos de 1 jugador");
            _active = true;
            EventDispatcher.PlayCardToField?.Invoke();

            //TODO:
            //seleccionar carta en campo y restaurarle 2 puntos de vida

            //hay que obtener los tile buttons de los gameobjects de la grilla del 30 al 35 o que estén activos
            


            // y agregarle el listener
            GetComponentInParent<Button>().onClick.AddListener(() => {
                    var goButton = transform.gameObject;
                    Heal(goButton);
                });
        }

        public void Heal(GameObject go) {
            if(IsActive) {
                //Debug.Log(go.name);
                TileCardController tileCardController = go.GetComponentInChildren<TileCardController>();
                tileCardController.Heal(_healPoints);
                _active = false;
                WasPlayed = true;
                //TODO: habria que eliminar el listener
            }
        }
    }
}
