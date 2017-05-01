using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxManager : MonoBehaviour {

    private Vector3 rotateAngle;

    // Use this for initialization
    void Start()
    {
        //set rotateangle
        rotateAngle = new Vector3(13, 30, 45);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate every frame
        transform.Rotate(rotateAngle * Time.deltaTime);


    }
    void OnTriggerEnter(Collider other)
    {
        //TODO when player pickup
        if (other.GetComponent<PlayerController>())
        {
            //Destroy(this.gameObject);
            GenerateItem();
        }
    }

    void GenerateItem()
    {
        //TODO Random the items
        StartCoroutine("Delay");
    }
    IEnumerator Delay()
    {
        //TODO Something?
        yield return null;
        Destroy(this.gameObject);

    }   
}
