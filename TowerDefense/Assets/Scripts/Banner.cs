using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{
   private string adUnitId = "Banner_Android"; // Troque para Banner_iOS se for iOS.
    void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        StartCoroutine(ShowBannerWithInterval());
    }
    IEnumerator ShowBannerWithInterval()
    {
        while (true)
        {
            Advertisement.Banner.Show(adUnitId);
            yield return new WaitForSeconds(10); // Mostrar por 10 segundos.
            Advertisement.Banner.Hide();
            yield return new WaitForSeconds(5);  // Ocultar por 5 segundos.
        }
    }
}
