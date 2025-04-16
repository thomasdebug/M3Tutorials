using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShootingBehavior : MonoBehaviour
{
    private Shoot shootScript;
    private ANImate1 ANImate1Script;
    public Transform target;
    public bool inCooldown;
    public float shotRange;
    public float coolDownTime;
    // Start is called before the first frame update
    void Start()
    {
      shootScript = GetComponentInChildren<Shoot>();
      ANImate1Script = GetComponentInChildren<ANImate1>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
        Vector3 delta = transform.position - target.position;
        if (delta.magnitude < shotRange && !inCooldown)
        {
            shootScript.CallShot();
            ANImate1Script.CallTrigger();
            inCooldown = true;
            StartCoroutine(Cooldown(coolDownTime));
        }
    }
    private IEnumerator Cooldown(float recieveCooldown)
    {
        
        yield return new WaitForSeconds(recieveCooldown);

        inCooldown = false;
    }
}
