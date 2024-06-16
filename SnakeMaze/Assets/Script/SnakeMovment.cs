using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovment : MonoBehaviour
{

    public float Speed;
    public float RotationSpeed;
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = -0.5f;
    
    public GameObject TailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        tailObjects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up*RotationSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1*RotationSpeed*Time.deltaTime);
        }

    }

    public void AddTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
        newTailPos.z -= z_offset;

        tailObjects.Add(GameObject.Instantiate(TailPrefab,newTailPos,Quaternion.identity) as GameObject);
    }
}
