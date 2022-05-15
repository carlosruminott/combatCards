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
    [SerializeField] private List<GameObject> _deck = new List<GameObject>();

    void Start()
    {
        Card cardScript = _card.GetComponent<Card>();
        Shufle();
        InstantiateDeckChilds(cardScript);
        //GetHand();
    }

    private void InstantiateDeckChilds(Card card)
    {
        for (int i = 0; i <= (_cardList.Count-1); i++)
        {
            card.CardInfo = _cardList[i];
            _deck.Add(_card);
            Instantiate(_card, gameObject.transform);
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

    public void ReShufle()
    {
        Card cardScript = _card.GetComponent<Card>();
        Transform deckTransform = gameObject.transform;
        int childCount = gameObject.transform.childCount - 1;
        for (int i = 0; i <= childCount; i++)
        {
            GameObject child = deckTransform.GetChild(i).gameObject;
            Destroy(child);
        }
        Shufle();
        InstantiateDeckChilds(cardScript);
        //GetHand();
    }
}
