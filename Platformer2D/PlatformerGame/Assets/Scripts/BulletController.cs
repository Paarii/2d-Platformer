using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 100;
    // Use this for initialization
    public GameObject hitimpact;

    public float DestroyTimeDelay;
    //public CameraShake camerashake;
    public AudioSource source;

    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
      
        Destroy(gameObject);
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        if (hitimpact != null)
        {
            GameObject newhit = Instantiate(hitimpact, pos, rot);
            Destroy(newhit, 2);


        }
       

    }
 



    private void OnTriggerEnter(Collider other)
    {
        GameObject newhit = Instantiate(hitimpact, transform.position, transform.rotation);

     
        if (hitimpact != null)
        {
            GameObject temp = (GameObject)Instantiate(hitimpact, transform.position, Quaternion.identity);
            Destroy(temp, 2);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
