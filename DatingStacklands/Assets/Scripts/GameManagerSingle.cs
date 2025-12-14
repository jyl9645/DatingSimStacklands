using UnityEngine;

public class GameManagerSingle : MonoBehaviour
{
    public static GameManagerSingle Instance;

    void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
