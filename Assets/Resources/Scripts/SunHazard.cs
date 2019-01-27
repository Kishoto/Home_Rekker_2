using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHazard : Hazard
{
    public Transform self;
    public float frequency = 0.25f;
    public float time = 5.0f;
    public int rayCount = 7;
    public float raySeparation = 0.5f;

    private bool sunny = false;
    private float nextRay = 0.0f;

    public override void StartHazard()
    {
        StartCoroutine("StartSun");
    }

    IEnumerator StartSun()
    {
        sunny = true;
        yield return new WaitForSeconds(time);
        sunny = false;
        finished = true;
    }

    void Update()
    {
        if (sunny && Time.time > nextRay)
        {
            float raySource = self.position.x - raySeparation * ((rayCount - 1) / 2);
            for (int i = 0; i < rayCount; i++)
            {
                RaycastHit hit;
                Vector3 source = new Vector3(raySource, self.position.y, self.position.z);
                if (Physics.Raycast(source, Vector3.down, out hit, 10.0f))
                {
                    if (hit.collider.CompareTag("Person"))
                    {
                        Figure figure = hit.collider.GetComponent<Figure>();
                        figure.heat += 1;
                        if (figure.heat >= 10)
                            figure._touched = true;
                    }
                }
                raySource += raySeparation;
            }
            nextRay = Time.time + frequency;
        }
    }
}
