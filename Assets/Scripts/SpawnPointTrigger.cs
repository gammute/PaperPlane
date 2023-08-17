using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointTrigger : MonoBehaviour
{
    LevelController lc;
    public GameObject targetLevel;

    void Start() 
    {
        lc = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            lc.currentLevel = targetLevel;
        }    
    }

    private void OnTriggerExit2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            if (lc.currentLevel == targetLevel)
            {
                lc.currentLevel = null;
            }
        }    
    }
}
