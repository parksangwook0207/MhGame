using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    [SerializeField] private Image invenimage;
 
    [SerializeField] private ScriptableObject itemdata;
     
    public int inX { get; set; }
    public int inY { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        inX = 4;
        inY = 10;
        Inven();      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Inven()  
    {
        for (int i = 0; i < inX * inY; i++)
        {
            Instantiate(prefab, parent);
        }
    }

    
}
