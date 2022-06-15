using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class FactionList : MonoBehaviour
    {
        public List<Faction> elementTypeList;
        public static FactionList instance;
     
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        /*private void Start()
        {
            Debug.Log(elementTypeList[0].ElementResistance);
        }*/
    }
}
