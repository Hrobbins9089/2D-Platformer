using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform player;

    //public float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && GameObject.Find("player").GetComponent<PlayerScript>().isAlive)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            transform.position = temp;
        }
    }
}
