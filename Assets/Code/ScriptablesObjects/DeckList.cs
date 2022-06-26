using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Game
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Game Data/New Deck", order = 3)]
    public class DeckList : ScriptableObject
    {

        [Header("Scriptable Card List")]
        public List<BaseCard> cardList;

        //public Dictionary<BaseCard, Image>

        public List<Deck> deck;

        [System.Serializable]
        public struct Deck
        {
            public BaseCard cardData;
            [Min(0)] public int count;
        }

        private void OnEnable() {
            cardList.Clear();
            var cards = AssetDatabase.FindAssets("", new[] {"Assets/Code/ScriptablesObjects/Cards"});
            foreach (string card in cards)
            {
                //Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
                var soPath = AssetDatabase.GUIDToAssetPath(card);
                cardList.Add(AssetDatabase.LoadAssetAtPath<BaseCard>(soPath));
            } 
        }

    }
}
