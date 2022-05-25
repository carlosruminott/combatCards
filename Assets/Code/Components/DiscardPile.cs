using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;

namespace Game.Components
{
    public class DiscardPile : MonoBehaviour
    {
        [SerializeField] private List<BaseCard> _DiscardPile;

        private void Awake()
        {
            EventDispatcher.Discard.AddListener(AddCard);
        }

        private void AddCard(BaseCard card)
        {
            _DiscardPile.Add(card);
        }
    }
}
