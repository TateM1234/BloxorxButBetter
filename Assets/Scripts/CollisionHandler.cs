using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CollisionHandler : MonoBehaviour
{
        [SerializeField] float LoadLevelDelay = 3f;
        bool isTransitioning = false;
        

        void OnCollisionEnter(Collision other)
        {
        Debug.Log("Collision");

            if (isTransitioning)
            {
                return;
            }
            switch (other.gameObject.name)
            {
                //Starts next level on collision 
                case "Complete":
                    StartSuccessSequence();
                    break;
                
                //resets level on collision 
            case "Obstical":
                StartCrashSequence();
                break;

                default:
                    break;
            }
        }

        private void StartSuccessSequence()
        {
            Invoke("LoadNextLevel", LoadLevelDelay);
        }

        void StartCrashSequence()
        {
            isTransitioning = true;
            GetComponent<PlayerMovement>().enabled = false;
            Invoke("ReloadLevel", LoadLevelDelay);
        }

        void LoadNextLevel()
        {
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = CurrentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);

        }

        void ReloadLevel()
        {
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CurrentSceneIndex);
        }
}

