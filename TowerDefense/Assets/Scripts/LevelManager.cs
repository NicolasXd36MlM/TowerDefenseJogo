using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{ 
    public static LevelManager main;
    public Transform[] caminho; //onde o inimigo vai passar
    public Transform começo;// onde aparece o inimigo

    private void Awake()
    {
        main = this;
    }
}
