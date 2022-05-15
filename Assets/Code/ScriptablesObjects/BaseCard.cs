using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Nueva Carta", order = 2)]
public class BaseCard : ScriptableObject
{
    //tipo de carta:
    //character: pesonaje jugable
    //item: curacion, sumar ataque
    //field: tarjeta que da alguna ventaja en campo
    public enum CardType
    {
        Character,
        Item,
        Field,
    };

    [Header("Card Type")]
    public CardType cardType;

    [Space(20)]
    [Header("Image")]
    public Sprite cardImage;
    
    [Space(20)]
    public string cardName;
    [TextArea(3, 10)] public string desciption;
    
    [Space(20)]
    [Header("Stadictycs")]
    public int healthPoints;
    public int defense;
    public int attack;
    [Header("ElementType")]
    public ScriptableObject elementalType;

    [Space(20)]
    [Header("Actions")]
    public int addHealthPoints;
    public int removeHealthPoints;

    [Space(20)]
    [Header("Hability")]
    [TextArea(3, 10)] public string habilityDesciption;

}
