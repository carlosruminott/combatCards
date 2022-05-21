using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Hand : MonoBehaviour
    {
        [Header("Deck")]
        [SerializeField] private GameObject _deck;

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
        private Deck _deckScript;

        private void Awake()
        {
            EventDispatcher.GetHand.AddListener(DeckList);
        }

        void Start()
        {
            _cardScript = _card.GetComponent<Card>();
            _deckScript = _deck.GetComponent<Deck>();
        }

        //private void OnEnable()
        //{
        //    EventGetHand += DeckList;
        //}

        //private void OnDisable()
        //{
        //    EventGetHand -= DeckList;
        //}

        public void DeckList()
        {
            var cardList = _deckScript.CardList;
            foreach (var item in cardList)
            {
                //Debug.Log(item.cardName);
                _deckList.Add(item);
            }
            HandList();
            InstantiateCard();
        }

        private void HandList()
        {
            for (int i = 0; i <= _initialNumHandCards; i++)
            {
                _handList.Add(_deckList[i]);
                _deckList.Remove(_deckList[i]);
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
            _deckScript.CardList.Clear();
            _deckScript.CardList = new List<BaseCard>(_deckList);
            _handList.Clear();
            _deckList.Clear();
            _deckScript.ShufleAndDraw();
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
