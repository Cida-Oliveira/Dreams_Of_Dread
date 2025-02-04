using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{
    public float vel = 2f;
    public Transform destino;

    public bool chegou = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!chegou && destino != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino.position, vel * Time.deltaTime);

            if(Vector2.Distance(transform.position, destino.position) < 1f)
            {
                chegou = true; //para o personagems
            }
        }
    }
}
