using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaRapida : InimigoPai
{
    public float aumentoDeVelocidade = 2f; // Quanto a velocidade aumenta ao ser atacado
    public int vida = 2; // Vida inicial do Inimigo3 (menor que os outros)

    private void Start()
    {
        // Inicializa a velocidade
        velocidade = 7f; // Defina a velocidade base do inimigo
        MoverInimigo();
    }

    // Método chamado quando o inimigo sofre dano
    public void TomarDano(int dano)
    {
        vida -= dano; // Subtrai a vida do inimigo
        velocidade += aumentoDeVelocidade; // Aumenta a velocidade ao ser atacado

        // Verifica se o inimigo foi destruído
        if (vida <= 0)
        {
            Destroy(gameObject); // Destrói o inimigo
        }
    }

}
