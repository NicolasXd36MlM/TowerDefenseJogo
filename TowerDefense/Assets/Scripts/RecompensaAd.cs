using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class RecompensaAd : MonoBehaviour
{
    public delegate void RewardAction();
    public RewardAction onAdRewarded;

    public string gameId = "5736777"; // Substitua pelo seu Game ID
    public bool testMode = true;

    private bool bannerActive = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ManageBannerAds());
    }

    private IEnumerator ManageBannerAds()
    {
        while (true)
        {
            if (!bannerActive && Advertisement.IsReady("banner"))
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show("banner");
                bannerActive = true;

                yield return new WaitForSeconds(10);
                Advertisement.Banner.Hide();
                bannerActive = false;

                yield return new WaitForSeconds(5);
            }
            yield return null;
        }
    }

    public void ShowInterstitialAd(System.Action onComplete)
    {
        string placementId = "Interstitial_Android";

        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
            onComplete?.Invoke(); // Chama o callback imediatamente
        }
        else
        {
            Debug.LogWarning("Anúncio intersticial não está pronto.");
            onComplete?.Invoke();
        }
    }

    public void ShowRewardedAd(RewardAction rewardAction)
    {
        onAdRewarded = rewardAction;

        string placementId = "Rewarded_Android";

        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
            StartCoroutine(RewardAfterDelay(5f)); // Recompensa após 5 segundos
        }
        else
        {
            Debug.LogWarning("Anúncio recompensado não está pronto.");
        }
    }

    private IEnumerator RewardAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        onAdRewarded?.Invoke(); // Recompensa o jogador
    }

    // Exemplo de outra lógica alternativa: recompensar ao completar uma tarefa
    public void CompleteTask()
    {
        // Lógica para completar uma tarefa
        onAdRewarded?.Invoke(); // Recompensa o jogador ao completar a tarefa
    }

    // Exemplo de recompensa em eventos especiais
    public void OnMilestoneReached()
    {
        onAdRewarded?.Invoke(); // Recompensa o jogador ao alcançar um marco
    }

    // Exemplo de recompensa diária
    public void DailyReward()
    {
        onAdRewarded?.Invoke(); // Recompensa diária
    }
}

