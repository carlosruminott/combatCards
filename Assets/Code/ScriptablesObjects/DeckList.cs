using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Deck", menuName = "New Deck", order = 3)]
    public class DeckList : ScriptableObject
    {
        [Header("Scriptable Card List")]
        [SerializeField] private List<BaseCard> _cardList;

        public List<BaseCard> CardList { get; set; }
    }
}
