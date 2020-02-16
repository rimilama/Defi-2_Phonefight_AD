using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_choice");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Break();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SeeInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }
}