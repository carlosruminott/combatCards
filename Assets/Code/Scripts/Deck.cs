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

        private void Awake()
        {
            EventDispatcher.Shuffle.AddListener(ShufleAndDraw);
        }

        void Start()
        {
            ShufleAndDraw();
        }

        public void ShufleAndDraw()
        {
            _deckList.cardList.Shuffle();
            EventDispatcher.GetHand?.Invoke();
        }
    }
}
