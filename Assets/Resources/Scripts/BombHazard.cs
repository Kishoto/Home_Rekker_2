using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHazard : Hazard
{
    public Transform self;
    public float countdown = 2.5f;
    public float bombRadius = 5.0f;
    public float bombForce = 500.0f;

    public override void StartHazard()
    {
        StartCoroutine("StartBomb");
    }

    IEnumerator StartBomb()
    {
        yield return new WaitForSeconds(countdown);
        Collider[] hits = Physics.OverlapSphere(self.position, bombRadius);
        foreach (Collider thing in hits)
        {
            Rigidbody rb = thing.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(bombForce, self.position, bombRadius);
            }
        }
        Destroy(self.gameObject);
    }
}
