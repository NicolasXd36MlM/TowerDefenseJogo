using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RecompensaAd : MonoBehaviour
{
    public int rewardAmount = 100; // Quantia de dinheiro como recompensa.

    public void ShowRewardedAd()
    {
        if (Advertisement.Banner.IsReady("Rewarded_Ad"))
        {
            ShowOptions options = new ShowOptions
            {
                resultCallback = result =>
                {
                    if (result == ShowResult.Finished)
                    {
                        Debug.Log("An�ncio assistido, recompensa concedida!");
                        playerEconomy.AddMoney(rewardAmount);
                    }
                    else if (result == ShowResult.Skipped)
                    {
                        Debug.Log("An�ncio pulado, nenhuma recompensa concedida.");
                    }
                    else
                    {
                        Debug.LogError("Erro ao exibir o an�ncio recompensado.");
                    }
                }
            };

            Advertisement.Show("Rewarded_Ad", options);
        }
        else
        {
            Debug.LogWarning("An�ncio recompensado n�o est� pronto.");
        }
    }
}
