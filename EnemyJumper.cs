using UnityEngine;
using System.Collections;


public class EnemyJumper : MonoBehaviour
{

    public float forceY = 300f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator; 

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        forceY = Random.Range(250, 550);
        myRigidbody.AddForce(new Vector2(0, forceY));
        myAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(1.5f);
        myAnimator.SetBool("attack", false);
        StartCoroutine(Attack());
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    void OnTriggerenter2D(Collider2D target)
    {
        if (target.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
