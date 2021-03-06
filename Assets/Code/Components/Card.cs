using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Game.Components.Abilities;

namespace Game.Components
{
    public class Card : MonoBehaviour
    {

        [SerializeField] private BaseCard _cardInfo;
        //[SerializeField] private SpriteRenderer _image;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name, _description, _hp, _defense, _attack, _elementalType, _hability;
        [SerializeField] private GameObject _characterFields;

        private Ability _ability;

        public BaseCard CardInfo
        {
            get
            {
                return _cardInfo;
            }
            set
            {
                _cardInfo = value;
            }
        }

        public GameObject CharacterFields { get; set; }

        void Start()
        {
            InitInfo();

        }

        public void InitInfo()
        {
            //Debug.Log(cardInfo.cardType);
            //Debug.Log(_cardInfo.elementalType);

            _image.sprite = _cardInfo.cardImage;
            _name.text = _cardInfo.cardName;
            _description.text = _cardInfo.desciption;

            /*if (_cardInfo.ability != null)
            {
                //TODO: ver cuando ejecutamos habilidad segun metodos de eactivación
                _ability = _cardInfo.ability.GetComponent(_cardInfo.ability.name) as Ability;
                _ability?.PlayAbility();
            }*/

            if (_cardInfo.cardType.ToString() == "Character")
            {
                _characterFields.SetActive(true);
                _hp.text = "HP: " + _cardInfo.healthPoints.ToString();
                _defense.text = "Def: " + _cardInfo.defense.ToString();
                _attack.text = "Att: " + _cardInfo.attack.ToString();
                _elementalType.text = "Type: " + _cardInfo.elementalType.ToString();
                //_hability.text = _cardInfo.habilityDesciption;
            }
        }

        /*public void PlayCard()
        {
            switch (_cardInfo.cardType)
            {
                case BaseCard.CardType.Character:
                    break;
                case BaseCard.CardType.Item:
                    break;
                case BaseCard.CardType.AttachableItem:
                    break;
                case BaseCard.CardType.Field:
                    break;
                default:
                    break;
            }
        }*/

    }
}
