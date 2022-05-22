using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Components
{
    public class Game : MonoBehaviour
    {
        //[System.Serializable] class NumcirclesChangedEvent : UnityEvent<int> { }
        //[SerializeField] NumcirclesChangedEvent sig_circlesChanged;

        //public void OnInit(CircularMovement i_circularMovement, int i_numCircles)
        //{
        //    sig_circlesChanged.Invoke(i_numCircles);

        private void Start()
        {
            //EventDispatcher.Shufle?.Invoke();
        }
    }
}
