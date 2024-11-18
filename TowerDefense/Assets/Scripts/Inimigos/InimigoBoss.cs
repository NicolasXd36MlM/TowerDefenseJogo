using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBoss : InimigoPai
{
    void Start()
    {
        vida = 10; // Um inimigo forte tem mais vida
        velocidade = 2f;
        Start(); // Chama o método Start da classe base
        MoverInimigo();
    }
  
}
