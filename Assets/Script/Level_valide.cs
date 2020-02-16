using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_valide : MonoBehaviour
{
    public Sprite Yes;
    public Sprite No;
    [SerializeField]
    private int Validation = 0;
    private string lvl_name;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = (int) char.GetNumericValue(this.name[this.name.Length - 1]);
        index = (index - this.transform.parent.transform.childCount +1 ) *-1;
        Validation = PlayerPrefs.GetInt(this.name, 0);
        if (index < this.transform.parent.transform.childCount-2)
        {
            int Valid_lvl_prec = PlayerPrefs.GetInt(this.transform.parent.transform.GetChild(index).name, 0);            
            if (Valid_lvl_prec == 0)
            {
                this.gameObject.GetComponent<Button>().interactable = false;
            }
        }

        if (Validation == 1)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Yes;
        }
        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = No;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getValidation()
    {
        return Validation;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(this.name);
    }

}
