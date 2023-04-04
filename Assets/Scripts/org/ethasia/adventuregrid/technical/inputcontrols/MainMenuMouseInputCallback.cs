using UnityEngine;
using UnityEngine.SceneManagement;

using Org.Ethasia.Adventuregrid.Technical.Mainmenucamerastates;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class MainMenuMouseInputCallback : MonoBehaviour
    {
        private bool waitForQuitGameExecution;
        private bool waitForNewGameStart;

        public void OnQuitButtonPressed()
        {
            if (!MainMenuCameraMan.GetInstance().IsMovingCamera())
            {
                MainMenuCameraMan.GetInstance().ChangeToQuitGame();
                waitForQuitGameExecution = true;
            }
        }

        public void OnNewGameButtonPressed()
        {
            if (!MainMenuCameraMan.GetInstance().IsMovingCamera())
            {
                MainMenuCameraMan.GetInstance().ChangeToNewGame();
                waitForNewGameStart = true;
            }
        }    

        void Update()
        {
            if (waitForQuitGameExecution && !MainMenuCameraMan.GetInstance().IsMovingCamera())
            {
                waitForQuitGameExecution = false;
                QuitGame();
            }

            if (waitForNewGameStart && !MainMenuCameraMan.GetInstance().IsMovingCamera())
            {
                waitForNewGameStart = false;
                StartNewGame();
            }            
        }

        private void QuitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }  

        private void StartNewGame()
        {
            SceneManager.LoadScene("OverworldScene");
        }
    }
}