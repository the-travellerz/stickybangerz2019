using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    // GET HANDLE for rigid body
    private Rigidbody2D _rigid2D;
    public float speedMultipliyer;
    // Start is called before the first frame update
    void Start()
    {
        //assign handle for rigid body
        _rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // set horizontal inputs for left and right

        float horitonalInput = Input.GetAxis("Horizontal");
        //velocity

        _rigid2D.velocity = new Vector2(horitonalInput*speedMultipliyer, _rigid2D.velocity.y);

    }
}
