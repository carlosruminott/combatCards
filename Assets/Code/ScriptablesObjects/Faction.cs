using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Faction", menuName = "Game Data/New Faction", order = 1)]
public class Faction : ScriptableObject
{
    public string factionName;
    public ScriptableObject factionWeakness;
    public ScriptableObject factionResistance;
}