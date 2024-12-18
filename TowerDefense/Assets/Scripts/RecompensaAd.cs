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
            
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show("banner");
                bannerActive = true;

                yield return new WaitForSeconds(10);
                Advertisement.Banner.Hide();
                bannerActive = false;

                yield return new WaitForSeconds(5);
            
        }
    }

    public void ShowInterstitialAd(System.Action onComplete)
    {
        string placementId = "Interstitial_Android";

        
            Advertisement.Show(placementId);
            onComplete?.Invoke(); // Chama o callback imediatamente
            Debug.LogWarning("An�ncio intersticial n�o est� pronto.");
            onComplete?.Invoke();
        
    }

    public void ShowRewardedAd(RewardAction rewardAction)
    {
        onAdRewarded = rewardAction;

        string placementId = "Rewarded_Android";

       
            Advertisement.Show(placementId);
            StartCoroutine(RewardAfterDelay(5f)); // Recompensa ap�s 5 segundos
            Debug.LogWarning("An�ncio recompensado n�o est� pronto.");
        
    }

    private IEnumerator RewardAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        onAdRewarded?.Invoke(); // Recompensa o jogador
    }

    // Exemplo de outra l�gica alternativa: recompensar ao completar uma tarefa
    public void CompleteTask()
    {
        // L�gica para completar uma tarefa
        onAdRewarded?.Invoke(); // Recompensa o jogador ao completar a tarefa
    }

    // Exemplo de recompensa em eventos especiais
    public void OnMilestoneReached()
    {
        onAdRewarded?.Invoke(); // Recompensa o jogador ao alcan�ar um marco
    }

    // Exemplo de recompensa di�ria
    public void DailyReward()
    {
        onAdRewarded?.Invoke(); // Recompensa di�ria
    }
}

