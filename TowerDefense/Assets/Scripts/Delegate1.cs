using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Delegates1 : MonoBehaviour
{
    public delegate void RewardAction();
    public RewardAction onAdRewarded;

    public string gameId = "5738841"; 
    public bool testMode = true;

    private bool bannerActive = false;
    private void Awake()
    {
        
    }
    void Start()
    {

        Advertisement.Initialize("5738841", testMode);
        StartCoroutine(ManageBannerAds());
        // Substitua pelo Game ID correto do Unity Dashboard
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameId = "5738841";
        }
    

        // Inicializa o Unity Ads (modo de teste ativado)
        Advertisement.Initialize("5738841", true);
    }

    private IEnumerator ManageBannerAds()
    {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show("banner");
                bannerActive = true;

                yield return new WaitForSeconds(10);
                Advertisement.Banner.Hide();
                bannerActive = false;

                yield return new WaitForSeconds(5);
           
    }

    public void ShowInterstitialAd(System.Action onComplete)
    {
        string placementId = "Interstitial_Android";


        Advertisement.Show(placementId);
            {

            }
        
       
    }

    public void ShowRewardedAd(RewardAction rewardAction)
    {
        onAdRewarded = rewardAction;

        if (onAdRewarded != null)
        {
            Advertisement.Show("Rewarded_Android");
        }
    }
}

