using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPickup : MonoBehaviour
{
    Renderer r;
    private AudioSource source;
    private ParticleSystem ps;
    private KeepScore scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
        scoreScript = FindObjectOfType<KeepScore>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            r.enabled = false;
            GameObject.Destroy(gameObject, 0.5f);
            source.Play();
            ps.Play();
            scoreScript.AddScore(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
