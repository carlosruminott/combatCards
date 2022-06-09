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
                    break;
                case BaseCard.CardType.Item:
                    PlayAbility();
                    Discard();
                    break;
                case BaseCard.CardType.AttachableItem:
                    PlayAbility();
                    AttachOnItem();
                    break;
                case BaseCard.CardType.Field:
                    PlayAbility();
                    PlaceOnField();
                    break;
                default:
                    break;
            }

        }

        private void Discard()
        {
            EventDispatcher.Discard?.Invoke(_cardScript.CardInfo);
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

        }

        private void AttachOnItem()
        {

        }
    }
}
