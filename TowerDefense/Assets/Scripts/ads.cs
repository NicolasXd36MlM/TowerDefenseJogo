using System.Collections;
using System.Collections.Generic;
using UnityEditor.Advertisements;
using UnityEngine;
using UnityEngine.Advertisements;
public class ads : MonoBehaviour
{

    public string adUnitId = "Interstitial_Android"; // Troque para Interstitial_iOS se for iOS.
    private bool canSkip = true;
    public void ShowAd()
    {
       AdvertisementSettings.testMode = true;
        if (Advertisement.IsReady(adUnitId))
        {
            var options = new ShowOptions { resultCallback = HandleAdResult };
            Advertisement.Show(adUnitId, options);
        }
    }
    private void HandleAdResult(ShowResult resultado)
    {
        // Após o anúncio, liberar a próxima onda.
        canSkip = !canSkip; // Alternar entre obrigatório e pulável.
    }
    public bool IsAdMandatory()
    {
        return !canSkip;
    }
}
