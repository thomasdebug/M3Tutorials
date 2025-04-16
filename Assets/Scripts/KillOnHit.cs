using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnHit : MonoBehaviour
{
    public string targetTag;
    public GameObject effect;
    private AudioSource audioSource;
    public Heart heartScript;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        handleHit(coll.gameObject);
    }
    private void OnTriggerEnter(Collider coll)
    {
        handleHit(coll.gameObject);
    }
    private void handleHit(GameObject other)
    {

        Debug.Log(1);
        if (other.tag == targetTag)
        {
            GameObject expl = Instantiate(effect);
            expl.transform.position = other.transform.position;
            Destroy(expl, 2f);
            if (targetTag == "Player")
            {
                Debug.Log(2);
                if (heartScript == null)
                {
                    Debug.Log(3);
                    heartScript = FindObjectOfType<Heart>();
                }
                heartScript.Lives--;
                if (heartScript.Lives == 0)
                {
                    Debug.Log(4);
                    Destroy(other, 0.1f);
                }
            }
            else
            {
                Destroy(other, 0.1f);
            }
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
