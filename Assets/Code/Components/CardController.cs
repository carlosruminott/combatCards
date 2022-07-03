using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Logic;
using Game.Components.Abilities;

namespace Game.Components
{
    public class CardController : MonoBehaviour
    {
        [SerializeField] private UserData m_player;

        private int _countActiveTiles;
        private int _countSelectedTiles;
        Card _cardScript;

        private void Awake()
        {
            Debug.Assert(m_player != null, "Player data not set in Card Controller");
            _cardScript = GetComponent<Card>();
            EventDispatcher.GetCountActiveTilesInField.AddListener(GetCountActiveTiles);
        }

        private void Update() {
            //_countSelectedTiles = Player.Instance.CountSelectedTiles;
            _countSelectedTiles = m_player.countSelectedTiles;
        }

        public void PlayCard()
        {
            // if(playerTurn)
            //_countActiveTiles = Player.Instance.CountActiveTiles;
            _countActiveTiles = m_player.countActiveTiles;
            // else if(IAturn)
            // _countActiveTiles = IA.Instance.countActiveTiles;

            switch (_cardScript.CardInfo.cardType)
            {
                case BaseCard.CardType.Character:
                    if(_cardScript.CardInfo.sacrificeCost != 0)
                    {
                        if(_countActiveTiles < _cardScript.CardInfo.sacrificeCost) {
                            Debug.Log("no se puede jugar esta carta al campo");
                            return;
                        }
                        if(_countActiveTiles >= _cardScript.CardInfo.sacrificeCost){
                            Debug.Log("se puede jugar esta carta al campo");
                            EventDispatcher.PlayCardToField?.Invoke();
                            EventDispatcher.PlayCardToFieldWithSacrifice?.Invoke();
                            StartCoroutine(CountSelectedTiles());
                        }
                    }else if(_countActiveTiles == 6) {
                        Debug.Log("ya no se puede jugar cartas al campo");
                        return;
                    }else {
                        if (CardHasHability()) PlayAbility();
                        PlaceOnField();
                        RemoveFromHand();
                    }
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

        private void Discard() => EventDispatcher.Discard?.Invoke(_cardScript.CardInfo);

        private void RemoveFromHand()
        {
            EventDispatcher.DiscardFromHand?.Invoke(_cardScript.CardInfo);
        }

        private bool CardHasHability()
        {
            return (_cardScript.CardInfo.ability) ? true : false ;
        }

        // TODO convertir en coroutine y que devuelva true cuando hablididad se jugó
        private void PlayAbility()
        {
            var abilityPrefab = _cardScript.CardInfo.ability;
            Debug.Log(abilityPrefab.name);
            Ability ability = abilityPrefab.GetComponent(abilityPrefab.name) as Ability;
            ability.OnActivate();
        }

        private void PlaceOnField()
        {
            EventDispatcher.SendInfoCard?.Invoke(_cardScript.CardInfo);
            EventDispatcher.PlayCardToField?.Invoke();
        }

        private void AttachOnItem(){}

        private void GetCountActiveTiles(int count)
        {
            //Debug.Log("count: " + count);
            //_countActiveTiles = count;
            //Player.Instance.CountActiveTiles = count;
            m_player.countActiveTiles = count;
        }

        IEnumerator CountSelectedTiles()
        {
            //_countSelectedTiles = Player.Instance.countSelectedTiles;
            //Debug.Log("coroutine countSelectedTiles: " + _countSelectedTiles);
            yield return new WaitUntil(() => _countSelectedTiles == _cardScript.CardInfo.sacrificeCost);
            //Debug.Log("coroutine end, discard tiles");
            EventDispatcher.DiscardTile?.Invoke();
            PlaceOnField();
            RemoveFromHand();
            //Player.Instance.CountSelectedTiles = 0;
            m_player.countSelectedTiles = 0;
        }
    }
}
