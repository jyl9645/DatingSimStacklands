using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public float heart = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHearts(float change)
    {
        heart += change;
        if (heart <= 0)
        {
            // code late, end game
        }
    }
}
