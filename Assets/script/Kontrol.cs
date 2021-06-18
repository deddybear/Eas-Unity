using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public float kecepatan = 10.0f;
    public string axis;

    public float batasAtas;
    public float batasBawah;
    // Start is called before the first frame update
    float gerak, nextPos;

    public int stackedBuff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (axis == "kiri")
        {
            gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;    
            nextPos = transform.position.y + gerak;
        }

        if (axis == "kanan")
        {
            gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;    
            nextPos = transform.position.y + gerak;
        }


        if (nextPos > batasAtas)
        {
            gerak = 0;
        }

        if (nextPos < batasBawah )
        {
            gerak = 0;
        }

        transform.Translate(0, gerak, 0);
    }
}
