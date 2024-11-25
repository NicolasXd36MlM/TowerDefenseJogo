using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public delegate void RewardAction(); // Delegate �nico para gerenciar recompensas
    public RewardAction onAdRewarded;   // Inst�ncia do delegate

    public string gameId = "1234567"; // Substitua pelo seu Game ID
    public bool testMode = true;

    private bool interstitialSkippable = true; // Alterna entre intersticiais pul�veis e n�o pul�veis
    private bool bannerActive = false;        // Controle de banners

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ManageBannerAds());
    }

    // Gerenciamento de Banners
    private IEnumerator ManageBannerAds()
    {
        while (true)
        {
            if (!bannerActive && Advertisement.IsReady("banner"))
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show("banner");
                bannerActive = true;

                yield return new WaitForSeconds(10); // Banner vis�vel por 10 segundos
                Advertisement.Banner.Hide();
                bannerActive = false;

                yield return new WaitForSeconds(5); // Pausa de 5 segundos
            }
            yield return null; // Evitar loop cont�nuo
        }
    }

    // Exibir intersticiais
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleInterstitialResult
            };

            Advertisement.Show("video", options);
        }
    }

    private void HandleInterstitialResult(ShowResult result)
    {
        if (result == ShowResult.Finished || result == ShowResult.Skipped)
        {
            Debug.Log("O intersticial foi fechado. Continuando o jogo.");
            onAdRewarded?.Invoke(); // Notificar que o intersticial terminou
        }
    }

    // Exibir an�ncios recompensados
    public void ShowRewardedAd(RewardAction rewardAction)
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            onAdRewarded = rewardAction; // Atribuir a��o de recompensa ao delegate

            var options = new ShowOptions
            {
                resultCallback = HandleRewardedResult
            };

            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleRewardedResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("An�ncio recompensado assistido.");
            onAdRewarded?.Invoke(); // Executar recompensa
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.Log("An�ncio recompensado pulado. Sem recompensa.");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Falha ao exibir o an�ncio recompensado.");
        }
    }
    public void ShowInterstitialAd(System.Action onComplete)
    {
        string placementId = "Interstitial_Android";

        if (Advertisement.GetPlacementState(placementId) == PlacementState.Ready)
        {
            Advertisement.Show(placementId, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished || result == ShowResult.Skipped)
                    {
                        Debug.Log("An�ncio intersticial finalizado.");
                        onComplete?.Invoke();
                    }
                }
            });
        }
        else
        {
            Debug.LogWarning("An�ncio intersticial n�o est� pronto.");
            onComplete?.Invoke();
        }
    }
    public void ShowRewardedAd(System.Action onReward)
    {
        string placementId = "Rewarded_Android";

        if (Advertisement.GetPlacementState(placementId) == PlacementState.Ready)
        {
            Advertisement.Show(placementId, new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished)
                    {
                        Debug.Log("An�ncio recompensado assistido!");
                        onReward?.Invoke();
                    }
                    else
                    {
                        Debug.Log("An�ncio recompensado n�o foi conclu�do.");
                    }
                }
            });
        }
        else
        {
            Debug.LogWarning("An�ncio recompensado n�o est� pronto.");
        }
    }
}
