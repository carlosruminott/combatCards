using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Game Data/New Deck", order = 3)]
    public class DeckList : ScriptableObject
    {

        [Header("Scriptable Card List")]
        public List<BaseCard> cardList;

        //public Dictionary<BaseCard, Image>

        public List<Deck> deck;

        [System.Serializable]
        public struct Deck
        {
            public BaseCard cardData;
            [Min(0)] public int count;
        }

    }
}
