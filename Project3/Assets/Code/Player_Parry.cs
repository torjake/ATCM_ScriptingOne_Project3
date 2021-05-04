using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Parry : MonoBehaviour
{
    float timer;
    public float ParryTimeLength;
    public bool isParrying = false;
    //
    public Animator animator;
    //
    public GameObject parryEffect;
    // Start is called before the first frame update
    void Start()
    {
        timer = ParryTimeLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timer == ParryTimeLength)
        {
            isParrying = true;   
        }
        if (isParrying == true)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                isParrying = false;
                timer = ParryTimeLength;
                animator.SetBool("Parry_Anim", false);
            }
        }
        //
        if (animator.GetBool("Parry_Anim") == true)
        {
            parryEffect.SetActive(true);
        }
        if (animator.GetBool("Parry_Anim") == false)
        {
            parryEffect.SetActive(false);
        }
        //
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
