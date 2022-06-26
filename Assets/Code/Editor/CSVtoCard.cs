using UnityEngine;
using UnityEditor;
using System.IO;

namespace Game.Editor {
    public class CSVtoCard
    {
        public static string cardsCSVPath = "/Code/Editor/CSVs/card-list.csv";

        private enum CardType
        {
            Character,
            Item,
            AttachableItem,
            Field,
        };

        [MenuItem("Card Utilities/Generate Cards")]
        public static void GenerateCards() {
            string[] AllLines = File.ReadAllLines(Application.dataPath + cardsCSVPath);

            foreach (var line in AllLines)
            {
                
                string[] splitData = line.Split(",");

                if(splitData[0] == "Type") continue;

                BaseCard card = ScriptableObject.CreateInstance<BaseCard>();

                //card.cardType = DefineCardType(splitData[0]);
                card.level = int.Parse(splitData[1]);
                //card.rarity = splitData[2];
                card.cardName = splitData[3];
                //card.elementalType = splitData[3]; // agregar ruta scriptable object
                card.energyCost = splitData[5] == "-" ? 0 : int.Parse(splitData[5]);
                card.sacrificeCost = splitData[6] == "-" ? 0 : int.Parse(splitData[6]);
                card.healthPoints = splitData[7] == "-" ? 0 : int.Parse(splitData[7]);
                card.attack = splitData[8] == "-" ? 0 : int.Parse(splitData[8]);
                card.defense = splitData[9] == "-" ? 0 : int.Parse(splitData[9]);
                card.lifeValue = splitData[10] == "-" ? 0 : int.Parse(splitData[10]);
                card.abilityDesciption = splitData[11];
                card.desciption = splitData[12];

                AssetDatabase.CreateAsset(card, $"Assets/Code/ScriptablesObjects/Cards/{card.cardName}.asset");
                
            }

            AssetDatabase.SaveAssets();
        }

        private static CardType DefineCardType(string type) {
            if(type == "Character") return CardType.Character;
            if(type == "Item") return CardType.Item;
            if(type == "Item Attachable") return CardType.AttachableItem;
            if(type == "Field") return CardType.Field;
            return CardType.Character;
        }
    }
}
