using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{

    [SerializeField] private BaseCard cardInfo;

    /*private string cardType;
    private Image cardImage;
    private string cardType;
    private TextMeshProUGUI cardDescription,*/

    void Start()
    {
        Debug.Log(cardInfo.cardType);
        Debug.Log(cardInfo.cardName);
    }
}
