using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    public int kecepatan = 100;
    int touchPadle;
    Rigidbody2D rigid;
    int scoreBiru;
    int scoreMerah;

    float tempSpdKanan;
    float tempSpdKiri;
    Text scoreUIBiru;
    Text scoreUIMerah;

    GameObject padleKiri;
    GameObject padleKanan;
    GameObject power;
    Power powerUp;
    Kontrol kiriProp;
    Kontrol kananProp;
    
    

    // Start is called before the first frame update
    void Start()
    {
        padleKiri  = GameObject.Find("kiri");
        padleKanan = GameObject.Find("kanan");
        power      = GameObject.Find("power");

        kiriProp  = padleKiri.GetComponent<Kontrol>();
        kananProp = padleKanan.GetComponent<Kontrol>();
        powerUp     = power.GetComponent<Power>();

        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(1,0).normalized;
        rigid.AddForce(arah * kecepatan);

        scoreBiru = 0;
        scoreMerah = 0;

        scoreUIBiru  = GameObject.Find("merah").GetComponent<Text>();
        scoreUIMerah = GameObject.Find("biru").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreBiru == 6)
        {
            Debug.Log("Pemenangnya Biru");
        }

        if (scoreMerah == 6)
        {
            Debug.Log("Pemenangnya Merah");
        }
    }

    void ResetBall()
    {
        kananProp.stackedBuff = 0; kiriProp.stackedBuff = 0;
        kiriProp.kecepatan = 10.0f; kananProp.kecepatan = 10.0f;
        padleKanan.transform.localScale = new Vector3(1f, 2.5f, 1f);
        padleKiri.transform.localScale = new Vector3(1f, 2.5f, 1f);
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore()
    {
        Debug.Log("Score M : "+ scoreMerah + "Score B : " + scoreBiru);
        scoreUIMerah.text = "Score Merah : " + scoreMerah ;
        scoreUIBiru.text  = "Score Biru  : " + scoreBiru  ;
    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
    

        if (coll.gameObject.name == "dkanan") {        
            scoreBiru += 1;
            kecepatan += 20;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(1, 0).normalized;
            rigid.AddForce(arah * kecepatan);
        }

        if (coll.gameObject.name == "dkiri") {
            scoreMerah += 1;
            kecepatan  += 20;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(-1, 0).normalized;
            rigid.AddForce(arah * kecepatan);
        }
        

        if (coll.gameObject.name == "kanan" || coll.gameObject.name == "kiri") {
            
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * kecepatan * 2);

            if (coll.gameObject.name == "kanan"){
                touchPadle = 1;
            }

            if (coll.gameObject.name == "kiri"){
                touchPadle = 2;
            }
        }

        if (coll.gameObject.name == "power")
        {
          powerUp.effectPower(touchPadle, Random.Range(0, 2));
        }

    }
}
