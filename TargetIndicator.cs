using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        if (GameObject.Find("player").GetComponent<PlayerScript>().facingRight == true)
        {
            var dir = Target.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (GameObject.Find("player").GetComponent<PlayerScript>().facingRight == false)
        {
            var dir = Target.position - transform.position;
            var angle = Mathf.Atan2(dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        }
    }
}
