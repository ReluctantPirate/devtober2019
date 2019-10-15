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

    [Header("Stats")]
    public int maxHP;
    public int statAttack;
    public int statDefense;
    public int statSpeed;

    [Header("Character Status")]
    public int remainingHP;
    public int energyRemaining;

    public int attackModifier = 0;
    public int defenseModifier = 0;
    public int speedModifier = 0;

    public bool immobilized = false;//when true, cannot take move actions
    public bool disarmed = false;//when true, cannot take attack actions
    public bool noDodge = false;//when true, cannot dodge an attack
    public bool willHit = false;//when true, will hit next attack

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

    public void receiveAttack(int characterAttack, int moveAttack, int characterSpeed, int moveSpeed)
    {
        //first decide if the attack even hits
        bool attackHits = true;
        if (noDodge || moveSpeed == 200)//special circumstances
        {
            attackHits = true;
        }
        else if (Random.Range(0, getCurrentSpeed()) < Random.Range(0, characterSpeed + moveSpeed))//normal dodge math. If your random speed number is less than theirs, you get hit
        {
            attackHits = true;
        }

        //if it hits, determine damage
        if (attackHits)
        {
            //determine damage
            int baseDamage = ((100 + characterAttack - getCurrentAttack())/100) * moveAttack;
            if(baseDamage < 1)//1 is minimum damage
            {
                baseDamage = 1;
            }
        }
    }

    int getCurrentAttack()
    {
        int currentAttack = statAttack;//default to the standard attack

        if (attackModifier > 0)
        {
            currentAttack += statAttack / 2;
        }
        else if (attackModifier < 0)
        {
            currentAttack -= statAttack / 2;
        }

        return currentAttack;
    }
    
    int getCurrentDefense()
    {
        int currentDefense = statDefense;//default to the standard defense

        if (defenseModifier > 0)
        {
            currentDefense += statDefense / 2;
        }
        else if (defenseModifier < 0)
        {
            currentDefense -= statDefense / 2;
        }

        return currentDefense;
    }

    int getCurrentSpeed()
    {
        int currentSpeed = statDefense;//default to the standard speed

        if (speedModifier > 0)
        {
            currentSpeed += statSpeed / 2;
        }
        else if (speedModifier < 0)
        {
            currentSpeed -= statSpeed / 2;
        }

        return currentSpeed;
    }
}
