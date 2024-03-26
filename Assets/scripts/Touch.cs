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
    float Hori;

    public float speed;
    Transform jogador;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (Direcao == Direcional.Dir)
        {
            Hori = 0;
        }
        else if (Direcao == Direcional.Esq)
        {
            Hori = 0;
        }
    }
}
