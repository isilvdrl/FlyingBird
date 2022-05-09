using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OyunKontrol :  MonoBehaviour
{
    public GameObject gokyuzuBir,gokyuzuIki;
    Rigidbody2D fizikBir, fizikIki;
    float uzunluk = 0;
    float arkaPlanHiz= -1.5f;
    public GameObject engel;
    public int kacAdetEngel;
    GameObject []engeller;
    int sayac;
    float degisimZaman;
    bool oyunDevam = true;
    void Start()
    {
        fizikBir = gokyuzuBir.GetComponent<Rigidbody2D>();
        fizikIki = gokyuzuIki.GetComponent<Rigidbody2D>();
        fizikBir.velocity = new Vector2(arkaPlanHiz, 0);
        fizikIki.velocity = new Vector2(arkaPlanHiz, 0);
        uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[kacAdetEngel];

        for(int i=0;i<engeller.Length;i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(-20,-20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(-1.5f,0);
        }
    }

   
    void Update()
    {
        if (oyunDevam)
        {

            if (gokyuzuBir.transform.position.x <= -uzunluk)
            {
                gokyuzuBir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzuIki.transform.position.x <= -uzunluk)
            {
                gokyuzuIki.transform.position += new Vector3(uzunluk * 2, 0);
            }

            //--------------------------

            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f)
            {
                degisimZaman = 0;
                float Yeksenim = Random.Range(-0.50f, 1.10f);
                engeller[sayac].transform.position = new Vector3(18, Yeksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }


            }
        }
    }
    public void oyunBitti()
    {
        for(int i=0;i<engeller.Length;i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            fizikBir.velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
        }
        oyunDevam = false;
        SceneManager.LoadScene("anaMenu");
       
    }
}
