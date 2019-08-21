using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D collider2D;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private bool isGrounded = true;
    [SerializeField]
    private float raycastdistance;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private bool isResetJumpNeeded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            Jump();  
        }

        Grounded();
    }

    void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpforce);
        isGrounded = false;
        isResetJumpNeeded = true;
        StartCoroutine(isResetJumpNeededRoutine());
    }

    private void Grounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down * raycastdistance, raycastdistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * raycastdistance, Color.green);

        if (hitinfo.collider != null)
        {
            if (isResetJumpNeeded == false)
            {
                isGrounded = true;
            }
        }
    }

    IEnumerator isResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        isResetJumpNeeded = false;
    }

}
