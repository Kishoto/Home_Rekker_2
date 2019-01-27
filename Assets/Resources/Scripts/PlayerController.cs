using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject cubeObj;
    public Transform placedObjectParent;
    internal static int addItemMaterial = 0;   //0 = wood, 1 = steel, 2 = brick
    internal static int addItemShape = 0;
    internal static int selectedItemMaterial = 0;
    internal static int selectedItemShape = 0;
    internal static Dictionary<string, int> inventory;
    public GameObject inventoryPanel;
    public bool selected;
    private int matcheck = 0;
    private int shapecheck = 0;

    private GameObject heldObject;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<string, int>
        {
            {"Cube-Hay", 0 },
            {"Cube-Wood", 0 },
            {"Cube-Metal", 0 },
            {"Rectangle-Hay", 0 },
            {"Rectangle-Wood", 0 },
            {"Rectangle-Metal",  0 },
            {"L-Hay", 0 },
            {"L-Wood", 0 },
            {"L-Metal", 0 },
            {"Hut-Hay", 0 },
            {"Hut-Wood", 0 },
            {"Hut-Metal", 0 },
            {"Triangle-Hay", 0 },
            {"Triangle-Wood", 0 },
            {"Triangle-Metal", 0 },
            {"Sphere-Hay", 0 },
            {"Sphere-Wood", 0 },
            {"Sphere-Metal", 0 }
        };
        //item = Instantiate();
        DrawInventory();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            //Debug.Log(selectedItemShape);
            //Debug.Log(GameData.objectMaterials[selectedItemMaterial]);
            Debug.Log("mouseOnPlayArea: " + GameData.mouseOnPlayArea);
            Debug.Log("items: " + (inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]));
            if (GameData.mouseOnPlayArea && inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]] > 0)
            {
                GameObject item = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity, placedObjectParent);
                item.transform.SetPositionAndRotation(new Vector3(item.transform.position.x, item.transform.position.y, -1), Quaternion.identity);
                inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]--;
                DrawInventory();
            }
        }
    }

    public void DrawInventory()
    {
        foreach(Transform t in inventoryPanel.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }
        foreach(KeyValuePair<string, int> item in inventory)
        {
            //Debug.Log(item.Key + " " + item.Value);
            //Debug.Log("Prefabs/Item-" + GameData.objectMap[item.type]);
            if (item.Value > 0)
            {
                //print(item.Key + item.Value);
                GameObject gO = Instantiate(Resources.Load<GameObject>("Prefabs/inventoryImages/" + item.Key), inventoryPanel.transform);
                gO.GetComponentInChildren<TMP_Text>().text = "x" + item.Value.ToString("N0");
            }
        }
    }

    public void InventoryItemSelected()
    {
        //Debug.Log("Hello");
        if(heldObject != null)
        {
            Destroy(heldObject);
            heldObject = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity, placedObjectParent);
            StartCoroutine("UpdateHeldObjectPos");
        }
        else
        {
            heldObject = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity, placedObjectParent);
            StartCoroutine("UpdateHeldObjectPos");
        }
    }

    IEnumerator UpdateHeldObjectPos()
    {
        while(true)
        {
            
            Debug.Log("1");
            bool error = false;
            try
            {
                if (inventory[heldObject.name.Replace("(Clone)", "")] <= 0)
                {
                    Destroy(heldObject);
                }
                heldObject.transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity);
            }
            catch (MissingReferenceException)
            {
                Debug.Log("error");
                error = true;
            }
            if (error) yield return null;
            else yield return new WaitForFixedUpdate();
        }
    }

    public void AddInventoryItem()
    {
        //Debug.Log(inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]);
        inventory[GameData.objectShapes[addItemShape] + "-" + GameData.objectMaterials[addItemMaterial]]++;
        DrawInventory();
    }


}
