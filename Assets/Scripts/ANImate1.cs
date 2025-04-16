using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANImate1 : MonoBehaviour
{
    public string triggerName;
    public float delay = 0f;
    public float resetTime;
    public KeyCode triggerKey = KeyCode.None;
    private Animator animator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            CallTrigger();
        }
    }
    public void CallTrigger()
    {
        StartCoroutine(AwaitDelay(delay));
        StartCoroutine(AwaitReset(resetTime));
    }
    private IEnumerator AwaitDelay(float time)
    {

        yield return new WaitForSeconds(time);
        animator.SetTrigger(triggerName);
        Debug.Log(1);
        if (audioSource != null) audioSource.Play();
    }
    private IEnumerator AwaitReset(float time)
    {

        yield return new WaitForSeconds(time);
 
        animator.ResetTrigger(triggerName);
    }
}
