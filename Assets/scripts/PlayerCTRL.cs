using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCTRL : MonoBehaviour
{
    public GameObject atirador;
    public float speed;
    Transform jogador;
    Vector3 limiteDir = new Vector3(4.5f, 0f,0f);
    Vector3 limiteEsq = new Vector3 (-4.5f, 0f, 0f);
    public bool duplicada = false;
    // Start is called before the first frame update
    void Start()
    {
        jogador = transform;

        limiteDir = new Vector3(4.5f, jogador.position.y, jogador.position.z);
        limiteEsq = new Vector3(-4.5f, jogador.position.y, jogador.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < limiteEsq.x)
        {
            transform.position = limiteEsq;
        } else if (transform.position.x > limiteDir.x)
        {
            transform.position = limiteDir;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Duplicate(1);
        }
    }

    public void Duplicate(int num)
    {
        for(int i = 0; i<num;i++)
        {
            GameObject nova_atirador = Instantiate(atirador, transform.position, transform.rotation, transform.parent);
        }
    }

    
}
