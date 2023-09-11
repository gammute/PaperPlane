using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOptimizer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        Debug.Log("destroyLEVEL");
    }
}
