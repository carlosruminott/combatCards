using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Logic
{
    // sacado de: https://www.youtube.com/watch?v=38D8AbR8TVU
    public static class EventDispatcher
    {
        public static UnityEvent Shuffle = new UnityEvent();
        public static UnityEvent GetHand = new UnityEvent();
        
        // para pasar funcion con parametros
        public static WhitParamEvent eventoconparamtro = new WhitParamEvent();
    }
    public class WhitParamEvent: UnityEvent<int> { }
}
