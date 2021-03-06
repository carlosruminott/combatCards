using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;

namespace Game.Components
{
    public class Hand : MonoBehaviour
    {
        [Header("Deck")]
        [SerializeField] private DeckList _soDeckList;

        [Space(10)]
        [Header("Card Prefab")]
        [SerializeField] private GameObject _card;

        [Space(10)]
        [Header("Config")]
        [SerializeField] private int _initialNumHandCards = 2;

        [Space(10)]
        [Header("Dynamic Hand")]
        [SerializeField] private List<BaseCard> _handList;
        [Header("Dynamic Deck")]
        [SerializeField] private List<BaseCard> _deckList;

        //public static System.Action EventGetHand;

        private Card _cardScript;

        private void Awake()
        {
            _cardScript = _card.GetComponent<Card>();
            EventDispatcher.GetHand.AddListener(DeckList);
            EventDispatcher.Discard.AddListener(RemoveSelectedCard);
            EventDispatcher.DiscardFromHand.AddListener(RemoveSelectedCard);
        }

        public void DeckList()
        {
            _deckList.Clear();
            foreach (var item in _soDeckList.cardList)
            {
                _deckList.Add(item);
            }
            HandList();
            InstantiateCard();
        }

        private void HandList()
        {
            var numCards = _deckList.Count - 1;
            if(_initialNumHandCards < numCards)
            {
                numCards = _initialNumHandCards;
            }
            //Debug.Log(numCards);
            while (numCards >= 0)
            {
                _handList.Add(_deckList[0]);
                _deckList.Remove(_deckList[0]);
                numCards--;
            }
        }

        private void InstantiateCard()
        {
            foreach (var item in _handList)
            {
                _cardScript.CardInfo = item;
                var go = (GameObject) Instantiate(_card, transform);
                go.transform.localScale = new Vector3(0.75f,0.75f,1);
                go.SetActive(true);
            }
        }

        public void ShuffleHand()
        {
            if(_handList.Count > 0)
            {
                foreach (var item in _handList)
                {
                    _deckList.Add(item);
                }
                RemoveCardsFromHand();
                _soDeckList.cardList.Clear();
                _soDeckList.cardList = new List<BaseCard>(_deckList);
                _handList.Clear();
                _deckList.Clear();
            } 
            EventDispatcher.Shuffle?.Invoke();
        }

        private void RemoveCardsFromHand()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        private void RemoveSelectedCard(BaseCard card)
        {
            foreach (Transform child in transform)
            {
                var cardName = child.gameObject.GetComponent<Card>().CardInfo.cardName;
                if (card.cardName == cardName)
                {
                    _handList.Remove(card);
                    _soDeckList.cardList.Remove(card);
                    Destroy(child.gameObject);
                    break;
                }
            }
        }

    }
}
