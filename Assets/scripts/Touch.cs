using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Direcional
    {
        Esq, Dir
    }

    public Direcional Direcao = Direcional.Dir;

    public float speed;
    Transform jogador;
    Vector3 limiteDir = new Vector3(4.5f, 0f, 0f);
    Vector3 limiteEsq = new Vector3(-4.5f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Transform>();

        limiteDir = new Vector3(4.5f, jogador.position.y, jogador.position.z);
        limiteEsq = new Vector3(-4.5f, jogador.position.y, jogador.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador.position.x < limiteEsq.x)
        {
            jogador.position = limiteEsq;
        }
        else if (jogador.position.x > limiteDir.x)
        {
            jogador.position = limiteDir;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (Direcao == Direcional.Dir)
        {
            jogador.transform.Translate(speed, 0, 0);
        }
        else if (Direcao == Direcional.Esq)
        {
            jogador.transform.Translate(-speed, 0, 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
