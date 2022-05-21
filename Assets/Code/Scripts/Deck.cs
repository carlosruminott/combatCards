using Game.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Deck : MonoBehaviour
    {
        [Header("Scriptable Card List")]
        [SerializeField] private List<BaseCard> _cardList;
        [SerializeField] private DeckList _deckList;

        [Header("Dynamic Deck")]
        [SerializeField] private List<BaseCard> _deckListDynamic;

        private BaseCard _tempBC;

        public List<BaseCard> CardList { get; set; }

        //private void Awake()
        //{
        //    EventDispatcher.Shufle.AddListener(ShufleAndDraw);
        //}

        void Start()
        {
            ShufleAndDraw();
            //EventDispatcher.Shufle?.Invoke();
            //_deckList.cardList.Shuffle();
        }

        private void Shufle()
        {
            for (int i = 0; i < _cardList.Count; i++)
            {
                int rnd = UnityEngine.Random.Range(0, _cardList.Count);
                _tempBC = _cardList[rnd];
                _cardList[rnd] = _cardList[i];
                _cardList[i] = _tempBC;
            }
        }

        public void ShufleAndDraw()
        {
            //Shufle();
            //Hand.EventGetHand();
            _deckList.cardList.Shuffle();
            EventDispatcher.GetHand?.Invoke();
        }
    }
}
