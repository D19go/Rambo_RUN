using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCTRL : MonoBehaviour
{

    public float speed;
    Transform jogador;
    // Start is called before the first frame update
    void Start()
    {
        jogador = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }

        
    }

    public void Duplicate(int num)
    {
        
    }

    
}
