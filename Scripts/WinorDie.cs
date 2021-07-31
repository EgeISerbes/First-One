using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinorDie : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    public void RestartClicked()
    {
        SceneManager.LoadScene("MainGame");
    }
}
