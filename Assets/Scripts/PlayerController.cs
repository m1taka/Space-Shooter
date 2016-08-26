using UnityEngine;
using System.Collections;




[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot, bomb; 
    public Transform shotSpawn, bombSpawn;
    public float fireRate;
    public float bombRate;
    private float nextBomb;
    private float nextFire;

    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone =
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetButton("Fire2") && Time.time > nextBomb)
        {
            nextBomb = Time.time + bombRate;
            //GameObject clone =
            Instantiate(bomb, bombSpawn.position, bombSpawn.rotation);
            GetComponent<AudioSource>().Play();      
        
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}