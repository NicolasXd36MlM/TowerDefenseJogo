using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;


public class LevelManager : MonoBehaviour
{
    public Transform pontoDeSpawn; // Ponto onde os inimigos serão instanciados
    public int quantidadeDeInimigosPorOnda = 18; // Quantidade de inimigos por onda
    public static LevelManager main; // Instância estática para acesso global
    public Transform[] caminho; // Onde o inimigo vai passar
    public Transform começo; // Onde aparece o inimigo
    public List<GameObject> ListaDeInimigosPrefab; // Lista de prefabs dos inimigos

    private int ondaAtual = 0; // Contador de ondas
    private bool exibindoAnuncio = false; // Controle de anúncios intersticiais

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        IniciarNovaOnda();
    }

    void IniciarNovaOnda()
    {
        if (exibindoAnuncio) return; // Garante que a nova onda só inicie após o anúncio

        ondaAtual++;

        if (ondaAtual > 1 && ondaAtual % 2 == 0) // Exibir intersticial a cada 2 ondas (a partir da segunda)
        {
            MostrarAnuncioIntersticial(() =>
            {
                InstanciarInimigosAleatorios(); // Inicia a nova onda após o anúncio
            });
        }
        else
        {
            InstanciarInimigosAleatorios(); // Inicia a nova onda diretamente
        }
    }

    void InstanciarInimigosAleatorios()
    {
        for (int i = 0; i < quantidadeDeInimigosPorOnda; i++)
        {
            // Escolhe um inimigo aleatório da lista
            int indiceAleatorio = Random.Range(0, ListaDeInimigosPrefab.Count);
            GameObject inimigoPrefab = ListaDeInimigosPrefab[indiceAleatorio];

            // Instancia o inimigo no ponto de spawn
            Instantiate(inimigoPrefab, pontoDeSpawn.position, Quaternion.identity);
        }

        Debug.Log($"Onda {ondaAtual} iniciada com {quantidadeDeInimigosPorOnda} inimigos.");
    }
    public void MostrarAnuncioIntersticial(System.Action aoTerminar)
    {
        string placementId = "Interstitial_Android"; // Substitua pelo ID do seu placement no painel Unity Ads

        if (Advertisement.GetPlacementState(placementId) == PlacementState.Ready)
        {
            Advertisement.Show(placementId, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished || result == ShowResult.Skipped)
                    {
                        aoTerminar?.Invoke(); // Continua após o anúncio
                    }
                    else
                    {
                        Debug.Log("O anúncio foi fechado antes de terminar.");
                        aoTerminar?.Invoke(); // Continua mesmo assim
                    }
                }
            });
        }
        else
        {
            Debug.LogWarning("Anúncio não está pronto.");
            aoTerminar?.Invoke(); // Continua diretamente se o anúncio não estiver disponível
        }
    }
}
