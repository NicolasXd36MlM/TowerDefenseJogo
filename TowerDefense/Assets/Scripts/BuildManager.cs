using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    [SerializeField]
    private GameObject[] PrefabTorre;

    private int torreSelecionada = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject pegaTorreSelecionada()
    {
        return PrefabTorre[torreSelecionada];
    }
}
