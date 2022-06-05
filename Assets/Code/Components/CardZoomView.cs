using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;

namespace Game.Components
{
    public class CardZoomView : MonoBehaviour
    {
        GameObject _childCard;
        Card _cardScript;

        private void Awake()
        {
            _childCard = gameObject.transform.GetChild(0).gameObject;
            _cardScript = _childCard.GetComponent<Card>();
            _childCard.SetActive(false);
            EventDispatcher.ZoomIn.AddListener(ShowCard);
            EventDispatcher.ZoomOut.AddListener(RemoveCard);
        }

        private void ShowCard(BaseCard info)
        {
            _childCard.SetActive(true);
            Debug.Log(info.cardName);
            _cardScript.CardInfo.cardName = info.cardName;
        }

        private void RemoveCard()
        {
            _childCard.SetActive(false);
        }
    }
}
