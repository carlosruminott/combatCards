using System.Collections;
using System.Collections.Generic;
using Game.Logic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Game.Components.Grid
{
    public class ShowInfoZoomOfThisTileCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] bool isDisabled = false;

        private void Awake()
        {
            EventDispatcher.PlayCardToField.AddListener(disableZoom);
            EventDispatcher.TileSapwned.AddListener(enableZoom);
        }

        private void disableZoom()
        {
            isDisabled = true;
        }

        private void enableZoom()
        {
            isDisabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isDisabled) return;
            //Debug.Log("overr");
            TileCardView _tileCardScript = transform.GetChild(1).gameObject.GetComponent<TileCardView>();
            EventDispatcher.ZoomIn?.Invoke(_tileCardScript.cardInfo);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isDisabled) return;
            //Debug.Log("exit");
            EventDispatcher.ZoomOut?.Invoke();
        }
    }
}
