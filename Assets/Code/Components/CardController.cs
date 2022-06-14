using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;
using Game.Components.Abilities;

namespace Game.Components
{
    public class CardController : MonoBehaviour
    {
        Card _cardScript;

        private void Awake()
        {
            _cardScript = GetComponent<Card>();
        }


        public void PlayCard()
        {
            switch (_cardScript.CardInfo.cardType)
            {
                case BaseCard.CardType.Character:
                    if (CardHasHability()) PlayAbility();
                    PlaceOnField();
                    RemoveFromHand();
                    break;
                case BaseCard.CardType.Item:
                    if (CardHasHability()) PlayAbility();
                    Discard();
                    break;
                case BaseCard.CardType.AttachableItem:
                    if (CardHasHability()) PlayAbility();
                    AttachOnItem();
                    RemoveFromHand();
                    break;
                case BaseCard.CardType.Field:
                    if (CardHasHability()) PlayAbility();
                    PlaceOnField();
                    RemoveFromHand();
                    break;
                default:
                    break;
            }

        }

        private void Discard()
        {
            EventDispatcher.Discard?.Invoke(_cardScript.CardInfo);
        }

        private void RemoveFromHand()
        {
            EventDispatcher.DiscardFromHand?.Invoke(_cardScript.CardInfo);
        }

        private bool CardHasHability()
        {
            return (_cardScript.CardInfo.ability) ? true : false ;
        }

        private void PlayAbility()
        {
            Ability ability = _cardScript.CardInfo.ability.GetComponent<Ability>();
            ability.OnActivate();
        }

        private void PlaceOnField()
        {
            EventDispatcher.SendInfoCard?.Invoke(_cardScript.CardInfo);
            EventDispatcher.PlayCardToField?.Invoke();
        }

        private void AttachOnItem()
        {

        }
    }
}
