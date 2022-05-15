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

    [Space(10)]
    [Header("Dynamic Hand")]
    [SerializeField] private List<GameObject> handList;

    public static System.Action EventGetHand;

    void Start()
    {
        //deckList = _deck.GetComponent<Deck>().deckList;
        //GetHand();
        EventGetHand += ShufleAndGetNewHand;
        StartCoroutine(StartHand());
    }

    private void GetHand()
    {
        float posX = _positionFirstCard;
        Transform deckTransform = _deck.transform;
        for (int i = 0; i <= _initialNumHandCards; i++)
        {
            GameObject child = deckTransform.GetChild(i).gameObject;
            child.transform.position = new Vector3(posX, 0, 0);
            var go = (GameObject) Instantiate(child, gameObject.transform);
            go.transform.position = new Vector3(posX, 0, 0);
            go.SetActive(true);
            handList.Add(go);
            Destroy(child);
            posX += _distanceOtherCard;
        }
    }

    private IEnumerator StartHand()
    {
        yield return new WaitForSeconds(2);
        //Transform deckTransform = _deck.transform;
        //GameObject child = deckTransform.GetChild(0).gameObject;
        //Instantiate(child, gameObject.transform);
        GetHand();
    }

    private void ShuffleHand()
    {
        Transform handTransform = gameObject.transform;
        int handCount = handList.Count - 1;
        for (int i = 0; i <= handCount; i++)
        {
            GameObject child = handTransform.GetChild(i).gameObject;
            Destroy(child);
        }
    }

    public void ShufleAndGetNewHand()
    {
        ShuffleHand();
        StartCoroutine(StartHand());
    }
}
