using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    float start = 0.0f;
    bool first = true;
    public bool win_fight;
    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(first == true)
        {
            if (Time.time - start < 0.5f)
            {
                this.transform.Translate(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            if (Time.time - start > 0.5f)
            {
                this.transform.Translate(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            if (Time.time - start > 1.5f)
            {
                first = false;
                start = Time.time;
            }
        }
        else
        {
            if (Time.time - start < 1.0f)
            {
                this.transform.Translate(1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            if (Time.time - start > 1.0f)
            {
                this.transform.Translate(-1 * Time.deltaTime, 1 * Time.deltaTime, 0);
            }
            if (Time.time - start > 2.0f)
            {
                start = Time.time;
            }
            
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemies")
        {
            Destroy(gameObject);
            if (this.win_fight == true)
            { 
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
                SceneManager.LoadScene("Level_choice");
            }
        }
    }
}
