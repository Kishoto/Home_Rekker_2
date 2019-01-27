using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardManager : MonoBehaviour
{
    private GameObject hazards;
    private bool triggered = false;
    private bool finished = false;
    private bool updated = false;
    public Button startButton;
    private Score_Display scoreHolder;

    void Start()
    {
        Physics2D.autoSimulation = false;
        hazards = GameObject.FindWithTag("Hazards");
        scoreHolder = GetComponent<Score_Display>();
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }

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
