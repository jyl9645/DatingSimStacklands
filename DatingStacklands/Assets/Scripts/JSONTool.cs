using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;
using Unity.VisualScripting;
using System;

public class JSONTool : MonoBehaviour
{
    string path;

    static FormulaList setList;

    [System.Serializable]
    public class FormulaList
    {
        public Formula[] list;
    }

    [System.Serializable]
    public class Formula
    {
        public Card.cardType[] requirements;
        public Card.cardType result;
    }

    void SaveToJson(FormulaList data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public void ReadFromJson()
    {
        if (File.Exists(path))
        {
            string jsonDrawn = File.ReadAllText(path);
            setList = JsonUtility.FromJson<FormulaList>(jsonDrawn);
        }
    }

    public static Card.cardType CompareFormulas(Card[] checkList)
    {
        Card.cardType resultingCard = Card.cardType.none;

        foreach (Formula formula in setList.list)
        {
            if (formula.requirements.Length != checkList.Length) continue;
            else
            {
                resultingCard = formula.result;
                Card.cardType[] tempreqs = (Card.cardType[])formula.requirements.Clone();

                foreach (Card card in checkList)
                {
                    if (!tempreqs.Contains(card.type))
                    {
                        print("no");
                        resultingCard = Card.cardType.none;
                    }
                    else
                    {
                        tempreqs[Array.IndexOf(tempreqs, card.type)] = Card.cardType.none;
                    }
                }

                if (resultingCard != Card.cardType.none)
                {
                    return resultingCard;
                }

            }
        }

        return Card.cardType.none;
    }

    void Start()
    {
        path = Application.persistentDataPath + "/formula.json";

        //THIS CODE IS FOR OVERWRITING THE JSON FILE; JSON HAS ALREADY BEEN SET SO WE DON'T HAVE TO KEEP RUNNING THIS EVERY START
        if (!File.Exists(path))
        {
            Formula[] formulaArray = new Formula[]
            {
               new Formula {requirements = new Card.cardType[] {Card.cardType.vinylItem, Card.cardType.espressoItem}, result = Card.cardType.coffeeDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.clothesItem, Card.cardType.magazineItem}, result = Card.cardType.mallDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.pretzelsItem, Card.cardType.ticketItem}, result = Card.cardType.arenaDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.flowersItem, Card.cardType.cakeItem}, result = Card.cardType.restaurantDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.magazineItem, Card.cardType.ticketItem}, result = Card.cardType.mallDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.cakeItem, Card.cardType.magazineItem}, result = Card.cardType.coffeeDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.ticketItem, Card.cardType.clothesItem}, result = Card.cardType.arenaDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.vinylItem, Card.cardType.ticketItem}, result = Card.cardType.arenaDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.flowersItem, Card.cardType.espressoItem}, result = Card.cardType.restaurantDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.flowersItem, Card.cardType.clothesItem}, result = Card.cardType.restaurantDate},
               new Formula {requirements = new Card.cardType[] {Card.cardType.flowersItem, Card.cardType.magazineItem}, result = Card.cardType.restaurantDate} 
            };

            FormulaList sampleList = new FormulaList();
            sampleList.list = formulaArray;

            SaveToJson(sampleList);
        }

        ReadFromJson();

    }
}
