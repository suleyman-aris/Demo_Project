using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [HideInInspector] public GameObject spawn;
    [HideInInspector] public GameObject spawn1;
    [HideInInspector] public GameObject mouse1Object;
    [HideInInspector] public GameObject mouse1ObjectPrev;
    [HideInInspector] public GameObject BuildPrev, redArea;
    bool canBuild = true;
    float gridCellX = 0.64f, gridCellY = 0.64f;
    Vector3 worldPos;
    [HideInInspector] public bool objectView;
    [HideInInspector] public bool mouse1ObjectViewBool;
    [HideInInspector] public GameObject buildObject;
    float hitX, hitY;

    private void Start()
    {
        redArea = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hitX = Mathf.Round(worldPos.x / gridCellX) * gridCellX;
        hitY = Mathf.Round(worldPos.y / gridCellY) * gridCellY;

        if (hitX <= 6f && hitX >= -3.6f && hitY <= 3.6f && hitY >= -6f)
        {
            if (objectView)
            {
                Destroy(mouse1ObjectPrev);
                objectView = false;
                BuildPrev = Instantiate(spawn, worldPos, transform.rotation);
            }
            else if (BuildPrev != null)
            {
                BuildPrev.transform.position = new Vector2(hitX, hitY);
                Destroy(BuildPrev.GetComponent<BoxCollider2D>());
            }
            if (mouse1ObjectViewBool)
            {
                Destroy(BuildPrev);
                mouse1ObjectViewBool = false;
                mouse1ObjectPrev = Instantiate(spawn1, transform.position, transform.rotation);
            }
            else if (mouse1ObjectPrev != null)
            {
                mouse1ObjectPrev.transform.position = new Vector2(hitX, hitY);
                Destroy(mouse1ObjectPrev.GetComponent<BoxCollider2D>());
            }




            canBuild = redArea.GetComponent<RedArea>().canBuild;

            if (Input.GetKeyDown(KeyCode.Mouse0) && canBuild && mouse1Object == null)
            {
                buildObject = Instantiate(spawn, transform.position, transform.rotation);
                buildObject.transform.position = new Vector2(hitX, hitY);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && canBuild && mouse1Object != null)
            {
                mouse1Object = Instantiate(spawn1, transform.position, transform.rotation);
                mouse1Object.transform.position = new Vector2(hitX, hitY);
                Debug.Log(mouse1Object.transform.position);
                mouse1Object = null;
                objectView = true;
            }




            if (!canBuild && BuildPrev != null)
            {
                BuildPrev.GetComponent<SpriteRenderer>().color = Color.red;                
            }
            else if (!canBuild && mouse1ObjectPrev != null)
            {
                mouse1ObjectPrev.GetComponent<SpriteRenderer>().color = Color.red;                
            }



            if (canBuild && BuildPrev != null)
            {
                SpriteRenderer sprite = BuildPrev.GetComponent<SpriteRenderer>();
                sprite.color = new Color(255, 255, 255, 100);
            }
            else if (canBuild && mouse1ObjectPrev != null)
            {
                SpriteRenderer sprite = mouse1ObjectPrev.GetComponent<SpriteRenderer>();
                sprite.color = new Color(255, 255, 255, 100);
            }



        }
        else if (BuildPrev != null)
        {
            Destroy(BuildPrev);
            objectView = true;
        }


        //Debug.Log(hitX + "   " + hitY);
    }
}
