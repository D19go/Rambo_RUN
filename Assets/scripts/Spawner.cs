using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timerSpawner;//mostrar o tempo entre um spawn e outro

    Transform tr;
    //Listas
    public List<GameObject> spawns = new List<GameObject>();
    List<float> posicao = new List<float>();
    //Config do spawn
    int rangeList;
    int objRandom;
    public bool podeSpawn;
    //Posicionar o spawn em diferentes lugares;
    Vector3 posicaoSpawn;// posição que ele vai ficar
    int po;
    float posiRandom;
    float valor = -4.5f;
    //Numero maximo de mobs para spawnar
    int numSpawn;
    int numSpawnMax = 11;
    void Start()
    {
        tr = transform;
        rangeList = spawns.Count;
        for (int i = 0; i<7; i++)
        {
            posicao.Add(valor);
            valor += 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSpawn)
        {
            objRandom = Random.Range(0, rangeList);
            numSpawn = Random.Range(1, numSpawnMax);// não to usando ainda
            po = Random.Range(0, posicao.Count);
            posiRandom = posicao[po];
            posicaoSpawn = new Vector3(posiRandom, transform.position.y, transform.position.z);
            transform.position = posicaoSpawn;
            SpawnOBJ(spawns[objRandom]);
            podeSpawn = false;
            StartCoroutine(TimerSpawn());
        }
    }

    void SpawnOBJ(GameObject prefab)
    {
        if (prefab.name == "Bonus_Onus")
        {
            GameObject nova_bola = Instantiate(prefab, transform.position, transform.rotation) ;
        }
        else
        {
            /*for (int i = 0; i < quantos; i++)
            {
            }*/
                GameObject nova_bola = Instantiate(prefab, transform.position, transform.rotation);
        }
    }

    IEnumerator TimerSpawn()
    {
        yield return new WaitForSeconds(timerSpawner);
        podeSpawn = true;
    }

    
}
