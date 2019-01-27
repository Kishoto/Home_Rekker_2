using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardManager : MonoBehaviour
{
    private GameObject hazards;
    private Score_Display scoreHolder;
    private bool triggered = false;
    private bool finished = false;
    private bool updated = false;
    public Button startButton;

    void Start()
    {
        hazards = GameObject.FindWithTag("Hazards");
        scoreHolder = GameObject.Find("Score Display").GetComponent<Score_Display>();

        startButton.onClick.AddListener(StartHazards);
    }

    void StartHazards()
    {
        if(!triggered)
        {
            Physics2D.autoSimulation = true;
            triggered = true;
            foreach (Hazard h in hazards.GetComponentsInChildren<Hazard>())
            {
                h.StartHazard();
            }
        }

    }

    void Update()
    {
        if (!finished)
        {
            finished = true;
            foreach (Hazard child in hazards.GetComponentsInChildren<Hazard>())
            {
                if (!child.finished)
                    finished = false;
            }
        }
        else if (!updated)
        {
            scoreHolder.UpdateScore();
            updated = true;
        }
    }
}
