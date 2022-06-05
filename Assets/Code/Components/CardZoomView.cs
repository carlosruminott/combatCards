using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;

namespace Game.Components
{
    public class CardZoomView : MonoBehaviour
    {
        //[SerializeField] private GameObject _card;

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
            //Debug.Log(info.cardName);
            _childCard.SetActive(true);
            _cardScript.CardInfo = info;
            _cardScript.InitInfo();
        }

        private void RemoveCard()
        {
            _childCard.SetActive(false);
        }
    }
}
