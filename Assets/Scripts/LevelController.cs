using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<GameObject> levels;
    public GameObject player;
    public float checkerRadius;
    Vector3 noLevelPosition;
    public LayerMask levelMask;
    Vector3 playerLastPosition;
    PlayerMovement pm;
    public GameObject currentLevel;

    [Header("Optimization")]
    public List<GameObject> spawnedLevels;
    public GameObject latestLevel;
    public float maxOpDistance;
    float opDist;

    void Start() 
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update() 
    {
        LevelChecker();
        LevelOptimizer();
    }

    void LevelChecker()
    {
        if (!currentLevel)
        {
            return;
        }

        if (!Physics2D.OverlapCircle(currentLevel.transform.Find("Spawn Point").position, checkerRadius, levelMask))
        {
            noLevelPosition = currentLevel.transform.Find("Spawn Point").position;
            SpawnLevel();
        }
    }

    void SpawnLevel()
    {
        int rand = Random.Range(0, levels.Count);
        latestLevel = Instantiate(levels[rand], noLevelPosition, Quaternion.identity);
        spawnedLevels.Add(latestLevel);
    }

    void LevelOptimizer()
    {
        foreach (GameObject level in spawnedLevels)
        {
            opDist = Vector3.Distance(player.transform.position, level.transform.position);
            if (opDist > maxOpDistance)
            {
                level.SetActive(false);
            }
        }
    }
}
