using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_Display : MonoBehaviour
{
    public Text scoretext;
    public int score;
    public int temp = 0;

    private GameObject Figures;
    // Start is called before the first frame update
    void Start()
    {
        Figures = GameObject.FindWithTag("People");
    }

    public void UpdateScore()
    {
        
        foreach (Figure x in Figures.GetComponentsInChildren<Figure>())
        {
            if (!x._touched)
            {
                temp = 100;
            }

            else
            {
                temp = 0;
            }
            score += temp;
        }
        
        scoretext.text = "Score: " + score;
    }
}
