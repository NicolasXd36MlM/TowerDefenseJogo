using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

    public class Banner : MonoBehaviour
    {
        private string adUnitId = "Banner_Android"; // Use "Banner_iOS" se for no iOS.
        private static bool isAdActive = false; // Rastreador global de anúncios ativos.

        void Start()
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            StartCoroutine(ShowBannerWithInterval());
        }

        IEnumerator ShowBannerWithInterval()
        {
            while (true)
            {
                if (!isAdActive)
                {
                    isAdActive = true; // Marca o banner como ativo.
                    Advertisement.Banner.Show(adUnitId);
                    yield return new WaitForSeconds(10); // Mostra por 10 segundos.
                    Advertisement.Banner.Hide();
                    isAdActive = false; // Marca o banner como inativo.
                }
                yield return new WaitForSeconds(5); // Aguarda 5 segundos antes de verificar novamente.
            }
        }
    }

