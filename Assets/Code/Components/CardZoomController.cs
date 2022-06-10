using Game.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Game.Components
{
    public class CardZoomController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("overr");
            Card _cardScript = GetComponent<Card>();
            EventDispatcher.ZoomIn?.Invoke(_cardScript.CardInfo);
            transform.DOMoveY(140, 0.3f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("exit");
            EventDispatcher.ZoomOut?.Invoke();
            transform.DOMoveY(110, 0.3f);
        }
    }
}
