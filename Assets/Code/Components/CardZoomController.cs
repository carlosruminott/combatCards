using Game.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.Components
{
    public class CardZoomController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] bool isDisabled = false;
        private Button _buttonCard;

        private void Awake()
        {
            EventDispatcher.PlayCardToField.AddListener(disableZoom);
            EventDispatcher.TileSapwned.AddListener(enableZoom);
            _buttonCard = GetComponent<Button>();
        }

        private void disableZoom()
        {
            isDisabled = true;
            _buttonCard.interactable = false;
        }

        private void enableZoom()
        {
            isDisabled = false;
            _buttonCard.interactable = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isDisabled) return;
            //Debug.Log("overr");
            Card _cardScript = GetComponent<Card>();
            EventDispatcher.ZoomIn?.Invoke(_cardScript.CardInfo);
            transform.DOMoveY(140, 0.3f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isDisabled) return;
            //Debug.Log("exit");
            EventDispatcher.ZoomOut?.Invoke();
            transform.DOMoveY(110, 0.3f);
        }
    }
}
