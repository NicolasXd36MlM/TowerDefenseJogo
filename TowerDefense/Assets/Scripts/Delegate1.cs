using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Delegates1 : MonoBehaviour
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

    public void ShowRewardedAd(RewardAction rewardAction)
    {
        onAdRewarded = rewardAction;

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
                        onAdRewarded?.Invoke();
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

