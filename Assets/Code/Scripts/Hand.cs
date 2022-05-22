using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
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
        [SerializeField] private float _positionFirstCard = -5f;
        [SerializeField] private float _distanceOtherCard = 3.5f;

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
        }

        public void DeckList()
        {
            foreach (var item in _soDeckList.cardList)
            {
                _deckList.Add(item);
            }
            HandList();
            InstantiateCard();
        }

        private void HandList()
        {
            for (int i = 0; i <= _initialNumHandCards; i++)
            {
                _handList.Add(_deckList[0]);
                _deckList.Remove(_deckList[0]);
            }
        }

        private void InstantiateCard()
        {
            float posX = _positionFirstCard;
            foreach (var item in _handList)
            {
                _cardScript.CardInfo = item;
                var go = (GameObject) Instantiate(_card, gameObject.transform);
                go.transform.position = new Vector3(posX, 0, 0);
                go.SetActive(true);
                posX += _distanceOtherCard;
            }
        }

        public void ShuffleHand()
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
            //_deckScript.ShufleAndDraw();
            EventDispatcher.Shuffle?.Invoke();
        }

        private void RemoveCardsFromHand()
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    }
}
