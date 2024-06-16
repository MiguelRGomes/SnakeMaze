using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float XSize = 8.8f;
    public float ZSize = 8.8f;
    public GameObject foodPrefab;
    public GameObject curFood;
    public Vector3 curPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab,curPos,Quaternion.identity) as GameObject;
    }
    void RandomPos()
    {
        curPos = new Vector3(Random.Range(XSize*-1, XSize),0.25f, Random.Range(ZSize*-1, ZSize));
    }

    void Update()
    {
        if(!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
