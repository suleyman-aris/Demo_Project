using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationProduction : MonoBehaviour
{
    public GameObject Soldier;

    public Sprite FindProduction(string[] splitValue)
    {
        Sprite a = Soldier.GetComponent<SpriteRenderer>().sprite;
        switch (splitValue[2])
        {
            case "Soldier":
                return Soldier.GetComponent<SpriteRenderer>().sprite;
                break;
            default:
                return a;
                break;
        }
        //return Soldier;
    }
}
