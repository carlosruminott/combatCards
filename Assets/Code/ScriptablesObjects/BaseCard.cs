using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Card", menuName = "Game Data/New Card", order = 2)]
public class BaseCard : ScriptableObject
{
    [Header("Image")]
    public Sprite cardImage;

    //tipo de carta:
    //character: pesonaje jugable
    //item: curacion, sumar ataque
    //field: tarjeta que da alguna ventaja en campo
    public enum CardType
    {
        Character,
        Item,
        AttachableItem,
        Field,
    };

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
    }

    [Space(20)]
    public CardType cardType;
    [Range(1, 4)] public int level = 1;
    public Rarity rarity;
    
    [Space(20)]
    public string cardName;
    [TextArea(3, 10)] public string desciption;

    [Space(20)]
    [Header("Costs")]
    [Min(0)] public int energyCost = 0;
    [Tooltip("Sacrifice of necessary field players, to be able to play this card to the field")]
    [Min(0)] public int sacrificeCost = 0;
    [Range(0,10)] public int lifeValue = 0;

    [Space(20)]
    [Header("Stadictycs")]
    [Min(0)] public int healthPoints;
    [Min(0)] public int defense;
    [Min(0)] public int attack;

    [Header("Faction")]
    public ScriptableObject elementalType;

    [Space(20)]
    [Header("Status")]
    public Condition condition;
    public bool itCanBeMoved = true;
    [Range(1, 3)]
    public int advanceBlocks  = 1;

    public enum Condition
    {
        Normal,
        Poisoned,
        Stunned,
        Intimidated,
        Sickly,
    };


    [Space(20)]
    [Header("Ability")]
    public GameObject ability;
    [TextArea(3, 10)] public string abilityDesciption;
}
