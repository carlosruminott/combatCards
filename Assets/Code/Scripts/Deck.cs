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
    public List<GameObject> deckList = new List<GameObject>();

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
        Card cardScript = _card.GetComponent<Card>();
        Shufle();
        InstantiateDeckChilds(cardScript);
    }

    private void InstantiateDeckChilds(Card card)
    {
        for (int i = 0; i <= (_cardList.Count-1); i++)
        {
            card.CardInfo = _cardList[i];
            deckList.Add(_card);
            Instantiate(deckList[i], gameObject.transform);
        }
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

    public void ReShufle()
    {
        Debug.Log("click");
        Card cardScript = _card.GetComponent<Card>();
        Transform deckTransform = gameObject.transform;
        int childCount = gameObject.transform.childCount - 1;
        for (int i = 0; i <= childCount; i++)
        {
            GameObject child = deckTransform.GetChild(i).gameObject;
            Destroy(child);
        }
        deckList.Clear();
        Shufle();
        InstantiateDeckChilds(cardScript);
        //GetHand();
        Hand.EventGetHand();
    }
}
