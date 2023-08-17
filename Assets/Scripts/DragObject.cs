using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag() 
    {
        rb2D.MovePosition(GetMousePosition());
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    private void OnEnable() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
