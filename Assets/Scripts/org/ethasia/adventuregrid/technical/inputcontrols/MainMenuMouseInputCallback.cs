using UnityEngine;
using UnityEngine.SceneManagement;

namespace Org.Ethasia.Adventuregrid.Technical.Inputcontrols
{
    public class MainMenuMouseInputCallback : MonoBehaviour
    {
        public void OnQuitButtonPressed()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void OnNewGameButtonPressed()
        {
            SceneManager.LoadScene("OverworldScene");
        }      
    }
}