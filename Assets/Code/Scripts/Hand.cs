using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Deck")]
    [SerializeField] private GameObject _deck;

    [Header("Config")]
    [SerializeField] private int _initialNumHandCards = 2;
    [SerializeField] private float _positionFirstCard = -5f;
    [SerializeField] private float _distanceOtherCard = 3.5f;

    void Start()
    {
        
    }

    private void GetHand()
    {
        float posX = _positionFirstCard;
        Transform deckTransform = _deck.transform;
        for (int i = 0; i <= _initialNumHandCards; i++)
        {
            GameObject child = deckTransform.GetChild(i).gameObject;
            child.SetActive(true);
            child.transform.position = new Vector3(posX, 0, 0);
            posX += _distanceOtherCard;
        }
    }
}
