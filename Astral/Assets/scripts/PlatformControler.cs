using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
    public Transform PositionA, PositionB;
    public int Speed;
    Vector2 targetPos;

    void Start()
    {
        targetPos = PositionB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PositionA.position) < .1f) targetPos = PositionB.position;

        if (Vector2.Distance(transform.position, PositionB.position) < .1f) targetPos = PositionA.position;

        transform.position = Vector2.MoveTowards(transform.position,targetPos,Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(PositionA.position, PositionB.position);
    }
}
