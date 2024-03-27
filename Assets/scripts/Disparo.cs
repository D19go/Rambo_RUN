using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SalvaPC", timer);   
    }

    // Update is called once per frame
    void SalvaPC()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision atingiu)
    {
        if (atingiu.gameObject.tag == "Boss" || atingiu.gameObject.tag == "Enemy")
        {
            atingiu.gameObject.GetComponent<Enemy>().Life(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
