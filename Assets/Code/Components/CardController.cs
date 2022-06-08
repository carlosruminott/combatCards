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
            Discard();
            //switch (_cardScript.CardInfo.cardType)
            //{
            //    case BaseCard.CardType.Character:
            //        break;
            //    case BaseCard.CardType.Item:
            //        Discard();
            //        break;
            //    case BaseCard.CardType.AttachableItem:
            //        break;
            //    case BaseCard.CardType.Field:
            //        break;
            //    default:
            //        break;
            //}

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
    }
}
