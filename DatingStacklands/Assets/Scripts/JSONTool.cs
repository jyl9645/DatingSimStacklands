using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;

public class JSONTool : MonoBehaviour
{
    string path;

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
            FormulaList flist = JsonUtility.FromJson<FormulaList>(jsonDrawn);
            foreach (Formula form in flist.list)
            {
                foreach (Card.cardType card in form.requirements)
                {
                    Debug.Log(card);
                }
                Debug.Log(form.result);
            }
        }
    }

    public void CompareFormulas(Card.cardType[] checkList)
    {
        
    }

    void Start()
    {
        path = Application.persistentDataPath + "/formula.json";

        //THIS CODE IS FOR OVERWRITING THE JSON FILE; JSON HAS ALREADY BEEN SET SO WE DON'T HAVE TO KEEP RUNNING THIS EVERY START

        //Formula[] formulaArray = new Formula[]
        //{
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.vinylItem, Card.cardType.espressoItem}, result = Card.cardType.coffeeDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.clothesItem, Card.cardType.magazineItem}, result = Card.cardType.mallDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.pretzelsItem, Card.cardType.ticketItem}, result = Card.cardType.arenaDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.flowersItem, Card.cardType.cakeItem}, result = Card.cardType.restaurantDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.magazineItem, Card.cardType.ticketItem}, result = Card.cardType.mallDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.cakeItem, Card.cardType.magazineItem}, result = Card.cardType.coffeeDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.ticketItem, Card.cardType.clothesItem}, result = Card.cardType.arenaDate},
        //   new Formula {requirements = new Card.cardType[] {Card.cardType.vinylItem, Card.cardType.ticketItem}, result = Card.cardType.arenaDate} 
        //};
//
        //FormulaList sampleList = new FormulaList();
        //sampleList.list = formulaArray;
//
        //SaveToJson(sampleList);
        
        ReadFromJson();

    }
}
