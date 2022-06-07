using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.Components
{
    public class CardZoomView : MonoBehaviour
    {
        //[SerializeField] private GameObject _card;

        [SerializeField] CanvasGroup _canvasGroup;

        GameObject _childCard;
        Card _cardScript;

        private void Awake()
        {
            Debug.Assert(_canvasGroup != null, "añadir canvas group al card zoom view");
            _childCard = gameObject.transform.GetChild(0).gameObject;
            _cardScript = _childCard.GetComponent<Card>();
            _canvasGroup.DOFade(0,0);
            _childCard.transform.DOScale(0.95f, 0);
            _childCard.SetActive(false);
            EventDispatcher.ZoomIn.AddListener(ShowCard);
            EventDispatcher.ZoomOut.AddListener(RemoveCard);
        }

        private void ShowCard(BaseCard info)
        {
            //Debug.Log(info.cardName);
            _childCard.SetActive(true);
            _canvasGroup.DOKill();
            _childCard.transform.DOKill();
            _canvasGroup.DOFade(1, 0.3f);
            _childCard.transform.DOScale(1f, 0.3f);
            _cardScript.CardInfo = info;
            _cardScript.InitInfo();
            if (_cardScript.CardInfo.cardType.ToString() != "Character")
            {
                GameObject stats = _childCard.transform.Find("Stats").gameObject;
                stats.SetActive(false);
            }
        }

        private void RemoveCard()
        {
            _childCard.transform.DOScale(0.95f, 0.5f);
            _canvasGroup.DOFade(0, 0.2f).OnComplete(()=>
            {
                _childCard.SetActive(false);
            });
        }
    }
}
