using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RecompensaAd : MonoBehaviour
{
    private string adUnitId = "Rewarded_Android"; // Troque para Rewarded_iOS se for iOS.
    private bool IsReady = true;
    private int resultadoResposta;
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(adUnitId))
        {
            var options = new ShowOptions { resultadoResposta = HandleAdResult };
            Advertisement.Show(adUnitId, options);
        }
    }
    private void HandleAdResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Conceder moeda ou continuar o jogo.
            Debug.Log("Recompensa concedida!");
        }
    }
}
