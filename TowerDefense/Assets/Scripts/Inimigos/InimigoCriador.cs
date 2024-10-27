using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoCriador : InimigoPai
{
    public GameObject prefabInimigo3; // Prefab do Inimigo3

    void Start()
    {
        vida = 4; // Configura a vida do Inimigo2
        velocidade = 4f;
        Start(); // Chama o método Start da classe base
        MoverInimigo();
    }
    public override void ReceberDano(int dano)
    {
        base.ReceberDano(dano); // Chama o método ReceberDano da classe base

        // Adiciona um novo Inimigo3 sempre que recebe dano
        AdicionarInimigo3();

        if (vida <= 0)
        {
            Destroy(gameObject); // Destrói o Inimigo2 se a vida chegar a 0
        }
    }

    private void AdicionarInimigo3()
    {
        Instantiate(prefabInimigo3, transform.position, Quaternion.identity);
        Debug.Log("Inimigo3 criado a partir do Inimigo2!");
    }
    void Update()
    {
        MoverInimigo(); // Move o inimigo no Update
    }
}