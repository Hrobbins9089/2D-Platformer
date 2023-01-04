using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles_2 : MonoBehaviour
{
    void Start()
    {
        if (Door_2.instance != null)
        {
            Door_2.instance.newcollectiblesCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("pickup touched");
            Destroy(gameObject);
            if (Door_2.instance != null)
            {
                Door_2.instance.DecrementCollectibles();
            }
        }
    }

}
