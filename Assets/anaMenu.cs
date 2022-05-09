using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaMenu : MonoBehaviour
{
    public Text puanText;
    public Text puanText2;
    // Start is called before the first frame update
    void Start()
    {
      
        int enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuankayit");
        puanText.text = "En Yuksek Puan = " + enYuksekPuan;
        int puan = PlayerPrefs.GetInt("Puankayit");
        puanText2.text = "Puan = " + puan;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OyunaGit()
    {
        SceneManager.LoadScene("SampleScene");
    }
   public void OyundanÇýk()
    {
        Application.Quit();
    }
}
