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
        //public static UnityEvent ZoomIn = new UnityEvent();
        public static UnityEvent ZoomOut = new UnityEvent();
        public static UnityEvent Ability = new UnityEvent();
        public static UnityEvent PlayCardToField = new UnityEvent();
        public static UnityEvent PlayCardToFieldWithSacrifice = new UnityEvent();
        public static UnityEvent TileSapwned = new UnityEvent();

        // para pasar funcion con parametros
        public static WhitParamEvent DiscardFromHand = new WhitParamEvent();
        public static WhitParamEvent Discard = new WhitParamEvent();
        public static WhitParamEvent ZoomIn = new WhitParamEvent();
        public static WhitParamEvent SendInfoCard = new WhitParamEvent();
        public static ParamInt SendInt = new ParamInt();
        public static ParamInt GetCountActiveTilesInField = new ParamInt();
    }
    public class WhitParamEvent: UnityEvent<BaseCard> { }
    public class ParamInt: UnityEvent<int> { }
}
