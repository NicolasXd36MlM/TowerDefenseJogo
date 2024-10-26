using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] private Rigidbody2D corpo;
    [SerializeField] private float velocidade = 3f;

    private Transform objetivo;
    private int caminhoIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = LevelManager.main.caminhos[caminhoIndex]; //define o caminho para o objetivo final
    }

    // Update is called once per frame
    void Update() //vai definir o objetivo final
    {
        if (Vector2.Distance(objetivo.position, transform.position) <= 0.1f) //checar se a distancia do objetivo esta na posição igual ou menor que 0.3
        {
            caminhoIndex++; //  vai aumentar em 1 a distancia do objetivo
            

            if (caminhoIndex >= LevelManager.main.caminhos.Length) // se o caminho foi menor ou igual o "final" 
            {
            Destroy(gameObject); //destroi o inimigo
            return; //cria um novo inimigo
            }
            else 
            {
                objetivo = LevelManager.main.caminhos[caminhoIndex];

            }
        }
    }
    private void CorrigirCaminho() // vai manter o inimigo no caminho certo e manter ele em direção ao objetivo
    {
        Vector2 direcao = (objetivo.position = transform.position).normalized;
    
        corpo.velocity = direcao * velocidade; //define que o corpo vai se mover para a proxima possição marcada
=======
    public float separacao = 1f;          // Distância entre inimigos
    public GameObject prefabInimigo;       // Prefab do inimigo
    public float velocidade = 5f;          // Velocidade do inimigo
    private Transform objetivo;             // Ponto de destino
    private int caminhoIndex = 0;          // Índice do caminho atual

    void Start()
    {
        AtualizarObjetivo();  // Define o primeiro objetivo do inimigo
    }
    void Update()
    {
        MoverInimigo();                    // Move o inimigo
    }
    void MoverInimigo()
        {
            if (objetivo == null) return; // Se não há objetivo, não faz nada

            // Move em direção ao objetivo
            transform.position = Vector2.MoveTowards(
                transform.position,
                objetivo.position,
                velocidade * Time.deltaTime
            );

            // Verifica se o inimigo chegou ao ponto atual
            if (Vector2.Distance(transform.position, objetivo.position) <= 0.3f)
            {
                caminhoIndex++; // Avança para o próximo ponto

                // Se for o fim do caminho, destrói o inimigo
                if (caminhoIndex >= LevelManager.main.caminho.Length)
                {
                    Destroy(gameObject);
                }
                else
                {
                    AtualizarObjetivo(); // Atualiza para o próximo ponto
                }
            }
        }
   

    void VerificarFimDoCaminho()
    {
        // Se o índice ultrapassar o tamanho do caminho, destrói o inimigo
        if (caminhoIndex >= LevelManager.main.caminho.Length)
        {
            Destroy(gameObject);  // Destroi o inimigo
        }
>>>>>>> Stashed changes
    }

    void AtualizarObjetivo()
    {
        if (caminhoIndex < LevelManager.main.caminho.Length)
        {
            objetivo = LevelManager.main.caminho[caminhoIndex];
            Debug.Log($"Objetivo atualizado para: {objetivo.name} (Índice: {caminhoIndex})");
        }
        else
        {
            objetivo = null;
            Debug.Log("Fim do caminho alcançado");
        }
    }

    void InstanciarInimigos(int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Vector3 posicaoSpawn = LevelManager.main.começo.position + new Vector3(i * separacao, 0, 0);
            GameObject novoInimigo = Instantiate(prefabInimigo, posicaoSpawn, Quaternion.identity);

            // Configura o objetivo inicial para o inimigo instanciado
            InimigoPai inimigoScript = novoInimigo.GetComponent<InimigoPai>();
            inimigoScript.AtualizarObjetivo();  // Define o primeiro objetivo

        }
    }

}