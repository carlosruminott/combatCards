using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ElementTypeList : MonoBehaviour
    {
        public List<Element> elementTypeList;
        public static ElementTypeList instance;
     
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
