using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInformation : MonoBehaviour
{
    public string FindObj(GameObject findObject)
    {
        string splitValue;
        switch (findObject.name)
        {
            case "Apartment":
                splitValue = Apartment();
                break;
            case "Cafe":
                splitValue = Cafe();
                break;
            case "Barracks":
                splitValue = Barracks();
                break;
            case "Home":
                splitValue = Home();
                break;
            case "Power Plant":
                splitValue = PowerPlant();
                break;
            case "Rezidance":
                splitValue = Rezidance();
                break;
            case "Shop":
                splitValue = Shop();
                break;
            case "Soldier":
                splitValue = Soldier();
                break;
            default:
                splitValue = "";
                break;
        }

        
        return splitValue;
    }

    string Apartment()
    {
        return "Apartment,2x2";
    }

     string Barracks()
    {
        return "Barracks,4x4,Soldier,1x1";
    }

     string Cafe()
    {
        return "Cafe,2x2";
    }

     string Home()
    {
        return "Home,2x1";
    }    

     string PowerPlant()
    {
        return "Power Plant,2x3";
    }

     string Rezidance()
    {
        return "Rezidance,2x2";
    }
    
     string Shop()
    {
        return "Shop,3x3";
    }

    string Soldier()
    {
        return "Soldier,1x1";
    }
    

}
