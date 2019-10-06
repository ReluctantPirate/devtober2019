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
    public int defenseRating;
    public int speedRating;
    public int remainingHP;


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

    public void receiveAttack(int attackSpeed, int attackPower)
    {
        bool attackHits = true;
        byte speedDiff = attackSpeed - speedRating;

        //work out the dodge chance
        float dodgeChance = 10;
        if (speedDiff > 0)//they are faster
        {
            //work out the chance of dodging from 1% to 10%
            dodgeChance = 10 - (9 * (Mathf.Abs(speedDiff)/99));
        } else if (speedDiff < 0)//you are faster
        {
            dodgeChance = 10 + (65 * (speedDiff / 99));
        }

        if(Random.Range(0,100) <= dodgeChance)
        {
            attackHits = false;
        }

        if (attackHits)
        {
            //take damage
            remainingHP -= Mathf.Round(attackPower * (defenseRating / 100f));
        }
    }
}
