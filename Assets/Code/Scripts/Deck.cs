using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<BaseCard> _cardList;
    [SerializeField] private GameObject _card;
    [SerializeField] private int _initialNumHandCards = 1;
    [SerializeField] private float positionFirstCard = 0;
    private BaseCard _tempBC;

    void Start()
    {
        Card cardScript = _card.GetComponent<Card>();
        Shufle();
        GetHand(cardScript);
    }

    private void SetInfoCard(Card card, int i)
    {
        card.CardInfo = _cardList[i];
        Instantiate(_card);
    }

    private void GetHand(Card card)
    {
        for (int i = 0; i < _initialNumHandCards; i++)
        {
            //card.CardInfo = _cardList[i];
            //Instantiate(_card);
            SetInfoCard(card,i);
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
