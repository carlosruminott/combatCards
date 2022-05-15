using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{

    [SerializeField] private BaseCard _cardInfo;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshPro _name, _description, _type, _hp, _defense, _attack, _elementalType, _hability;

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

    void Start()
    {
        //Debug.Log(cardInfo.cardType);
        //Debug.Log(cardInfo.cardName);

        _image.sprite = _cardInfo.cardImage;
        _name.text = _cardInfo.cardName;
        _description.text = _cardInfo.desciption;
        _type.text = _cardInfo.cardType.ToString();
        _hp.text = _cardInfo.healthPoints.ToString();
        _defense.text = _cardInfo.defense.ToString();
        _attack.text = _cardInfo.attack.ToString();
        //_elementalType.text = _cardInfo.elementalType.elementName;
        _hability.text = _cardInfo.habilityDesciption;
    }
}
