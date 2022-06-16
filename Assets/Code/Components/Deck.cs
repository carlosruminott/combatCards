using Game.Utils;
using Game.Logic;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Components
{
    public class Deck : MonoBehaviour
    {
        [Header("Scriptable Card List")]
        [SerializeField] private DeckList _deckList;

        [Header("Dynamic Deck")]
        [SerializeField] private List<BaseCard> _deckListDynamic;

        private void Awake()
        {
            PopulateDeck();
            EventDispatcher.Shuffle.AddListener(ShufleAndDraw);
        }

        void Start()
        {
            ShufleAndDraw();
        }

        private void PopulateDeck()
        {
            _deckList.cardList.Clear();
            foreach (var card in _deckList.deck)
            {
                for (int i=0; i < card.count; i++)
                {
                    _deckList.cardList.Add(card.cardData);
                }
            }
        }

        public void ShufleAndDraw()
        {
            _deckList.cardList.Shuffle();
            EventDispatcher.GetHand?.Invoke();
        }

    }
}
