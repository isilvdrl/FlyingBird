using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kontrol : MonoBehaviour
{

    public Sprite []KusSprite;
    SpriteRenderer spriteRenderer;
    bool ileriGeriKontrol = true;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puanText;
    bool oyunDevam = true;
    OyunKontrol oyunKontrol;
    int enYuksekPuan = 0;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
        enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuankayit");
        Debug.Log("eyk="+enYuksekPuan);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& oyunDevam)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
        }
        if(fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 0, -45);

        }
        Animasyon();
       
    }

    void Animasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;
            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;

                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }



            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="puan")
        {
            puan++;
            puanText.text = /*"Puan = " + */" " +puan;
            
        }
        if (col.gameObject.tag == "engel")
        {
            oyunDevam = false;
            oyunKontrol.oyunBitti();

            PlayerPrefs.SetInt("Puankayit", puan);
            //GetComponent<CircleCollider2D>().enabled = false;

            if (puan>enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("enYuksekPuankayit", enYuksekPuan);
            }
        }
    }

}
