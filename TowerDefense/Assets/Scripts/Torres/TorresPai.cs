using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorresPai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            InimigoPai inimigo = other.GetComponent<InimigoPai>();
            if (inimigo != null)
            {
                inimigo.ReceberDano(1); // Aplica 1 de dano
            }
            Destroy(gameObject); // Destroi o tiro
        }
    }
}
