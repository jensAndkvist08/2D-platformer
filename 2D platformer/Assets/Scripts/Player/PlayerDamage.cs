using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerDamage : MonoBehaviour
{
    //[SerializeField] int playerHealth = 5;
    [SerializeField] float iFrameTime = 1f;
    bool iFrameOn = false;
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hazard") && iFrameOn == false)
        {

            FindFirstObjectByType<GameSession>().ProcessPlayerDamage();
            iFrameOn = true;
            Invoke("IFrameOver", iFrameTime);
            //playerHealth--;
            //if (playerHealth <= 0)
            //{
            //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //    Destroy(gameObject);
            //    SceneManager.LoadScene(currentSceneIndex);
            //}
            //else
            //{
            //    iFrameOn = true;
            //    Invoke("IFrameOver", iFrameTime);
            //}
        }
    }

    void IFrameOver()
    {
        iFrameOn = false;
    }
}
