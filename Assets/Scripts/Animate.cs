using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            ani.SetTrigger("Dance");
            ani.ResetTrigger("Idle");
        }
        else
        {
            ani.SetTrigger("Idle");
            ani.ResetTrigger("Dance");
        }
    }
}
