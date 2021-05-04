using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FireBall : MonoBehaviour
{
    float Speed;
    public Rigidbody2D rb;
    public GameObject spawnPoint;
    //
    public GameObject Player_Ref;
    //
    public Animator animator;
    //
    public AudioSource pain;
    public AudioSource parry;
    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(5, 15);
        print(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.left * Speed * Time.fixedDeltaTime);
        //
        if (rb.transform.position.x < -14f)
        {
            rb.position = spawnPoint.transform.position;
            Speed = Random.Range(5, 15);
            animator.SetBool("Damage_Anim", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (Player_Ref.GetComponent<Player_Parry>().isParrying == true)
            {
                print("Parry");
                rb.position = spawnPoint.transform.position;
                animator.SetBool("Parry_Anim", true);
                //
                parry.enabled = false;
                parry.enabled = true;
            }
            if (Player_Ref.GetComponent<Player_Parry>().isParrying != true)
            {
                print("hit");
                animator.SetBool("Damage_Anim", true);
                //
                pain.enabled = false;
                pain.enabled = true;
            }
        }
    }
}
