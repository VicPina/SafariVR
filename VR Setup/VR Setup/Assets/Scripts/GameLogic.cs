using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal" || other.tag == "Bullet")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
