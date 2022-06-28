using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

namespace Game.Editor {

    public class CSVtoCard
    {
        public static string cardsCSVPath = "/Code/Editor/CSVs/card-list.csv";

        [MenuItem("Card Utilities/Generate Cards")]
        public static void GenerateCards() {
            string[] AllLines = File.ReadAllLines(Application.dataPath + cardsCSVPath);

            foreach (var line in AllLines)
            {
                
                //string[] splitData = line.Split(",");
                string[] splitData = Regex.Split(line, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if(splitData[0] == "Type") continue;

                BaseCard card = ScriptableObject.CreateInstance<BaseCard>();
                
                card.cardType = DefineCardType(splitData[0]);
                card.level = int.Parse(splitData[1]);
                card.rarity = DefineRarity(splitData[2]);
                card.cardName = splitData[3];
                //card.elementalType = splitData[3]; // agregar ruta scriptable object
                card.energyCost = SanatizeInt(splitData[5]) ;
                card.sacrificeCost = SanatizeInt(splitData[6]) ;
                card.healthPoints = SanatizeInt(splitData[7]);
                card.attack = SanatizeInt(splitData[8]);
                card.defense = SanatizeInt(splitData[9]);
                card.lifeValue = SanatizeInt(splitData[10]);
                // card.ability = splitData[11]; // instanciar prefab ability
                card.abilityName = splitData[11];
                card.abilityDesciption = RemoveQuote(splitData[12]);
                card.desciption = RemoveQuote(splitData[13]);

                card.elementalType = LoadSO(splitData[4]);

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

        private static Rarity DefineRarity(string rarity) {
            if(rarity == "Common") return Rarity.Common;
            if(rarity == "Epic") return Rarity.Epic;
            if(rarity == "Rare") return Rarity.Rare;
            if(rarity == "Legendary") return Rarity.Legendary;
            return Rarity.Common;
        }

        private static int SanatizeInt(string s) {
            if(s.Length == 0) return 0;
            return int.Parse(s.Trim().Replace("-", "0"));
        }

        private static string RemoveQuote(string s) {
            if(s.Length == 0) return "";
            return s.Trim('"');
        }

        private static ScriptableObject LoadSO(string factionName) {
            var fsos = AssetDatabase.FindAssets(factionName, new[] {"Assets/Code/ScriptablesObjects/Factions"});

            foreach (string faction in fsos)
            {
                //Debug.Log(AssetDatabase.GUIDToAssetPath(faction));
                var soPath = AssetDatabase.GUIDToAssetPath(faction);
                return AssetDatabase.LoadAssetAtPath<ScriptableObject>(soPath);
            }
            return null;
        }
    }
}
