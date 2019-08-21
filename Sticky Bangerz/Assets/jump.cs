using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D collider2D;
    [SerializeField]
    public float jumpforce;
    public bool isGrounded = true;
    public float raycastdistance;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();

        }

        Grounded();
        OnCollisionEnter();
    }

    void Jump()
    {
        // jump function
        // is grounded
        if (isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpforce);
            isGrounded = false;
        }
        
    }

    private void Grounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, raycastdistance);

        if (hitinfo.collider != null)
        {
            isGrounded = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }



    }


}
