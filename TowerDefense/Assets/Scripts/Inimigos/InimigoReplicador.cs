using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoReplicador : InimigoPai
{
    public GameObject prefabInimigo3; // Prefab do Inimigo3

    void Start()
    {
        vida = 5; // Configura a vida do Inimigo4
        velocidade = 5f;
    }
    public override void ReceberDano(int dano)
    {
        base.ReceberDano(dano); // Chama o método ReceberDano da classe base

        if (vida <= 0)
        {
            CriarNovosInimigos(); // Chama o método para criar novos inimigos
        }
    }
    private void CriarNovosInimigos()
    {
        for (int i = 0; i < 2; i++) // Cria 2 novos Inimigo3
        {
            Vector3 posicaoSpawn = transform.position + new Vector3(i * separacao, 0, 0); // Define a posição do spawn
            Instantiate(prefabInimigo3, posicaoSpawn, Quaternion.identity); // Instancia o novo inimigo
            Debug.Log("Inimigo3 criado a partir do Inimigo4!");
        }
    }
}
