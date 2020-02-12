using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class Reco_voc : MonoBehaviour
{
    public string[] MotsReco = new string[] { "ah", "space", "down", "up", "left", "right"};
    public ConfidenceLevel confidence = ConfidenceLevel.High;
    protected KeywordRecognizer recognizer;

    public Button but_atk;
    public GameObject Attaque;
    public GameObject Cible;
    public Transform Canvas;

    private string message;
    // Start is called before the first frame update
    void Start()
    {
        recognizer = new KeywordRecognizer(MotsReco, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Waiting()
    {
        but_atk.gameObject.GetComponent<Button>().interactable = false;
        recognizer.Start();
        
        
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs arg)
    {
        GameObject NewAttaque = Instantiate(Attaque, new Vector3(0, -2.5f, 1), new Quaternion(0, 0, 0, 0), Canvas);
        message = arg.text;
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            if (arg.text == "ah")
            {
                message = "[ā]";
                NewAttaque.GetComponent<Movement>().win_fight = true;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level_2")
        {
            if (arg.text == "ah")
            {
                message = "A";
                NewAttaque.GetComponent<Movement>().win_fight = true;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level_3")
        {
            if(arg.text == "Space")
            {
                message = "[spās]";
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            if(arg.text == "Space")
            {
                NewAttaque.GetComponent<Movement>().win_fight = true;
            }
        }


        if (arg.text == Cible.gameObject.GetComponent<Text>().text)
        {
            NewAttaque.GetComponent<Movement>().win_fight = true;
        }
        NewAttaque.GetComponent<Text>().text = message;
        
        but_atk.gameObject.GetComponent<Button>().interactable = true;
        recognizer.Stop();
    }
}
