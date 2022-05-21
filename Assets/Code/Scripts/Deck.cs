using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Deck : MonoBehaviour
    {
        [Header("Scriptable Card List")]
        [SerializeField] private List<BaseCard> _cardList;
        [SerializeField] private DeckList _deckList;

        private BaseCard _tempBC;

        public List<BaseCard> CardList
        {
            get
            {
                return _cardList;
            }
            set
            {
                _cardList = value;
            }
        }

        //private void Awake()
        //{
        //    EventDispatcher.Shufle.AddListener(ShufleAndDraw);
        //}

        void Start()
        {
            ShufleAndDraw();
            //EventDispatcher.Shufle?.Invoke();
        }

        private void Shufle()
        {
            for (int i = 0; i < _cardList.Count; i++)
            {
                int rnd = Random.Range(0, _cardList.Count);
                _tempBC = _cardList[rnd];
                _cardList[rnd] = _cardList[i];
                _cardList[i] = _tempBC;
            }
        }

        public void ShufleAndDraw()
        {
            Shufle();
            //Hand.EventGetHand();
            EventDispatcher.GetHand?.Invoke();
        }
    }
}
