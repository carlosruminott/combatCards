using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<BaseCard> _cardList;
    [SerializeField] private GameObject _card;
    [SerializeField] private int _initialNumHandCards = 2;
    [SerializeField] private float _positionFirstCard = -5f;
    [SerializeField] private float _distanceOtherCard = 3.5f;
    private BaseCard _tempBC;

    void Start()
    {
        Card cardScript = _card.GetComponent<Card>();
        Shufle();
        GetHand(cardScript);
    }

    private void GetHand(Card card)
    {
        float posX = _positionFirstCard;
        for (int i = 0; i <= _initialNumHandCards; i++)
        {
            card.CardInfo = _cardList[i];
            Instantiate(_card, new Vector3(posX,0,0), Quaternion.identity);
            posX += _distanceOtherCard;
        }
    }

    private void Shufle()
    {
        for (int i = 0; i < _cardList.Count; i++)
        {
            int rnd = Random.Range(0, _cardList.Count);
            _tempBC = _cardList[rnd];
            _cardList[rnd] = _cardList[i];
            _cardList[i] = _tempBC;
        }
    }
}
