using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Components.Grid;
using Game.Logic;

namespace Game.Components
{
    public class Game : MonoBehaviour
    {
        public static Game Instance;
        public FieldGrid fieldScript;

        [SerializeField] private GameObject m_fieldGrid;

        private void Awake() {
            if(Instance == null) Instance = this;
            Debug.Assert(m_fieldGrid != null, "missing field grid game object on [" + gameObject.name + "]");
            fieldScript = m_fieldGrid.GetComponent<FieldGrid>();
            EventDispatcher.SendInt.AddListener(ShowLogActiveTiles);
        } 

        private void ShowLogActiveTiles(int nada) {
            foreach (var item in fieldScript.activeTiles)
            {
                Debug.Log(item);
            }
        }
    }
}
