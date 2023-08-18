using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public TMP_Text levelDisplay;
    public int currentLevel = 0;

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
        levelDisplay.text = string.Format("Level: " + "{0}", currentLevel);
    }

    public void Kill()
    {
        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LevelUp"))
        {
            currentLevel++;
        }
    }
}
