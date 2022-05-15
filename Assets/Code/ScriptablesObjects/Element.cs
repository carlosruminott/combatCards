using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementalType", menuName = "Nuevo Tipo de Elemento", order = 1)]
public class Element : ScriptableObject
{
    public string elementName;
    public ScriptableObject elementWeakness;
    public ScriptableObject ElementResistance;
}