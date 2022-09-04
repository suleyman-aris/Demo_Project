using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArea : MonoBehaviour
{
    public bool canBuild = true;
    [HideInInspector]public bool mouse1Bool;
    public RaycastHit2D hit;
    GameObject mouse1ClickObject;
    [HideInInspector] public GameObject portable;

    private void Start()
    {
        mouse1ClickObject = GameObject.FindGameObjectWithTag("MainCamera");
        mouse1Bool = true;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Vector2.zero, 100f);

        if (hit.collider == null)
        {
            canBuild = true;
        }
        else if (hit.transform.tag == "NotBuildable")
        {
            canBuild = false;
            if (Input.GetKeyDown(KeyCode.Mouse1) && portable == null )
            {
                portable = hit.transform.gameObject;
                mouse1ClickObject.GetComponent<Build>().mouse1ObjectPrev = portable;
                mouse1ClickObject.GetComponent<Build>().spawn1 = portable;
                mouse1ClickObject.GetComponent<Build>().mouse1Object = portable;
                mouse1ClickObject.GetComponent<Build>().mouse1ObjectViewBool = true;
                portable = null;
                Debug.Log("1");
            }
        }
    }
}

