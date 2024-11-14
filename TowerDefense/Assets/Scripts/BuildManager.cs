using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    [SerializeField] private GameObject[] PrefabTorre;

    private int Terreno = 80;

    private void Awake()
    {
        main = this;
    }

    public GameObject PegaTorreSelecionada()
    {
        return PrefabTorre[Terreno];
    }
}
