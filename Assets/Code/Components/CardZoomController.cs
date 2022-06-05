using Game.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Components
{
    public class CardZoomController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("overr");
            Card _cardScript = GetComponent<Card>();
            EventDispatcher.ZoomIn?.Invoke(_cardScript.CardInfo);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("exit");
            EventDispatcher.ZoomOut?.Invoke();
        }
    }
}
