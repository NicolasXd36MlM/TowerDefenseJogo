using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{ 
    public static LevelManager main;
    public Transform[] caminhos; //onde o inimigo vai passar
    public Transform come�o;// onde aparece o inimigo
    private void Awake()
    {
        main = this;
    }
}