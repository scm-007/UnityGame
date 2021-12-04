using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "DeadZone")
        {
            Destroy(gameObject);
            print("OnCollisionEnter");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            Destroy(gameObject);
            print("OnTriggerEnter");
        }
    }
    public Vector2 RandomOnUnitCircle2(float radius)
    {
        Vector2 randomPointOnCircle = Random.insideUnitCircle;
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        transform.position = randomPointOnCircle;
        return randomPointOnCircle;
    }
}
