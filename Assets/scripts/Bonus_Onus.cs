using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Onus : MonoBehaviour
{

    int qual;// se for 1 é bom, 2 é aleatorio e 3 é ruim;
    
    List<int> bonus = new List<int>();
    List<int> onus = new List<int>();
    List<int> todos = new List<int>();
    
    int sorteio;
    
    public float speed;
    
    bool sorteioFeito= true;
    
    GameObject player;
    Renderer     mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>();

        player = GameObject.FindWithTag("Player");
        sorteioFeito = true;
        qual = Random.Range(1,4);
        Debug.Log(qual);

        bonus.Add(1);// aumenta a cadencia de disparo e a força dele
        bonus.Add(2);// multiplicador de atiradores
        onus.Add(3);//subtrai a quantidade de atiradores
        onus.Add(4);//diminui a cadencia
        //daqui para baixo os resultados são iguais aos de cima
        todos.Add(1);
        todos.Add(2);
        todos.Add(3);
        todos.Add(4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
        if (sorteioFeito)
        {
            if (qual == 1)
            {
                sorteio = Random.Range(1,bonus.Count+1);
                mat.material.color = Color.green;
            } else if (qual == 2)
            {
                sorteio = Random.Range(1, todos.Count + 1);
                mat.material.color = Color.yellow;
            }
            else if (qual == 3)
            {
                sorteio = Random.Range(1, onus.Count+1);
                mat.material.color = Color.red;
            }
            sorteioFeito = false;
        }
        if (transform.position.z <= -24)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider ot)
    {
        if (ot.gameObject.tag == "Atiradores" && qual == 1)// bonus
        {
            if (sorteio == 1)
            {
                //aumenta a cadencia do disparo
                ot.gameObject.GetComponentInChildren<Shotter>().LVL(0.05f, 1000);
                Destroy(gameObject);
            }
            else
            {
                //duplica o numero de jogadores
                GameObject nova_atirador = Instantiate(ot.gameObject);
                nova_atirador.transform.parent = player.transform;
                Destroy(gameObject);
            }
            
        }
        else if (ot.gameObject.tag == "Atiradores" && qual == 2)//neutro
        {
            if (sorteio == 1)
            {
                //aumenta a cadencia do disparo
                ot.gameObject.GetComponentInChildren<Shotter>().LVL(0.05f, 1000);
                Destroy(gameObject);
            }else if(sorteio == 2)
            {
                //duplica o numero de jogadores
                GameObject nova_atirador = Instantiate(ot.gameObject);
                nova_atirador.transform.parent = player.transform;
                Destroy(gameObject);
            }else if (sorteio == 3)
            {
                ot.gameObject.GetComponentInChildren<Shotter>().LVL(1f, 200);
                Destroy(gameObject);
            }
            else
            {
                Destroy(ot.gameObject);// diminui o numero de jogador
                Destroy(gameObject);
            }
        }
        else if (ot.gameObject.tag == "Atiradores" && qual == 3) //Onus
        {
            if (sorteio == 1)
            {
                ot.gameObject.GetComponentInChildren<Shotter>().LVL(1f, 200);
                Destroy(gameObject);
            }
            else
            {
                Destroy(ot.gameObject);
                Destroy(gameObject);
            }
        }

    }


}
