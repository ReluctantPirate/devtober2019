using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterHandler : MonoBehaviour
{
    [Header("Hookups")]
    public GameObject[] perches;
    public GameObject buttonRow;
    public int currentPerch;

    [Header("Character Status")]
    public int energyRemaining;
    public float defensePoints;
    public int woundPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = perches[currentPerch].transform.position;
    }

    public void advanceCharacter()
    {
        if(currentPerch + 1 < perches.Length)//there are still places to advance to
        {
            currentPerch++;
            energyRemaining--;
        }
    }

    public void retreatCharacter()
    {
        if(currentPerch > 0)//there are still places to reatreat to
        {
            currentPerch--;
            energyRemaining--;
        }
    }

    public void declareAttack(int type)
    {

    }
}
