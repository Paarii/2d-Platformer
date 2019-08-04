using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootType
{
    None, 
    Fire
    //More to add
};

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10;
    public int jumpForce = 10;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private bool m_FacingRight;


    //Weapon vars
    [SerializeField] private ShootType shootTypes;
    private float nextFire;
    public float fireRate;
    public GameObject[] weapons;
    public Transform firePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x,y);

        Walk(dir);
        Shoot();
        if (x < 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x > 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(Vector2.up);

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

       
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x *speed, rb.velocity.y);
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale > 0 && Time.time > nextFire)
        {
            
            switch (shootTypes)
            {
                case ShootType.None:
                    //just use normal slash to kill enemy
                case ShootType.Fire:
                    nextFire = Time.time + fireRate;
                    Debug.Log("shooting fire");
                
                    Instantiate(weapons[0], firePoint.position, firePoint.rotation);
                    break;
                default:
                    break;
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
