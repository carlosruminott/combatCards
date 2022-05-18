using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [Header("Scriptable Card List")]
    [SerializeField] private List<BaseCard> _cardList;

    [Space(20)]
    [Header("Card Prefab")]
    [SerializeField] private GameObject _card;

    private BaseCard _tempBC;

    public List<BaseCard> CardList
    {
        get
        {
            return _cardList;
        }
        set
        {
            _cardList = value;
        }
    }

    void Start()
    {
        Shufle();
        Hand.EventGetHand();
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

    public void ShufleAndDraw()
    {
        Shufle();
        Hand.EventGetHand();
    }
}
