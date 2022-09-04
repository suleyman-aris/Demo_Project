using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInformation : MonoBehaviour
{
    public GameObject spawnObject;
    private bool objectPrevView = true;

    public GameObject informationPanel;

    public void ButtonImage()
    {        
        GameObject.Find("Main Camera").GetComponent<Build>().spawn = spawnObject;   
        GameObject.Find("Main Camera").GetComponent<Build>().objectView = objectPrevView;

        

        string spliteValue = GameObject.Find("_Scripts").GetComponent<ObjectInformation>().FindObj(spawnObject);

        string[] objectData = spliteValue.Split(',');

        informationPanel.transform.GetChild(1).gameObject.SetActive(true);
        informationPanel.transform.GetChild(2).gameObject.SetActive(true);
        informationPanel.transform.GetChild(3).gameObject.SetActive(true);
        informationPanel.transform.GetChild(1).GetComponent<Text>().text = objectData[0];
        informationPanel.transform.GetChild(2).GetComponent<Text>().text = objectData[1];
        informationPanel.transform.GetChild(3).GetComponent<Image>().sprite = spawnObject.GetComponent<SpriteRenderer>().sprite;
        if(objectData.Length == 4)
        {
            informationPanel.transform.GetChild(4).gameObject.SetActive(true);
            informationPanel.transform.GetChild(5).gameObject.SetActive(true);
            informationPanel.transform.GetChild(6).gameObject.SetActive(true);
            informationPanel.transform.GetChild(4).GetComponent<Text>().text = objectData[2];
            informationPanel.transform.GetChild(5).GetComponent<Image>().sprite = GameObject.Find("_Scripts").GetComponent<InformationProduction>().FindProduction(objectData);
            informationPanel.transform.GetChild(6).GetComponent<Text>().text = objectData[2];
        }
        else
        {
            informationPanel.transform.GetChild(4).gameObject.SetActive(false);
            informationPanel.transform.GetChild(5).gameObject.SetActive(false);
            informationPanel.transform.GetChild(6).gameObject.SetActive(false);
        }


    }
}
