using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    int maxPlayerHealth;

    void Awake()
    {
        int numGameSession = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        maxPlayerHealth = playerHealth;
    }

    public void ProcessPlayerDamage()
    {
        if(playerHealth > 1)
        {
            TakeDamage();
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Destroy(gameObject);
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    void TakeDamage()
    {
        playerHealth--;
    }
    void Update()
    {
        
    }
}
