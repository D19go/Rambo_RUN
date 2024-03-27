using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator ani;
    public float run;
    public float boss_Run;

    public int Vida;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        if (transform.tag == "Boss")
        {
            ani.SetBool("BOSS", true);
            Vida *= 2;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Boss")
        { 
            transform.Translate(0, 0, boss_Run * Time.deltaTime);
        }
        else
        {

            transform.Translate(0,0, run * Time.deltaTime);
        }
    }

    public void Life(int dano)
    {
        Vida -= dano;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void WavesMult(int newVida)
    {
        Vida = newVida;
    }
}
