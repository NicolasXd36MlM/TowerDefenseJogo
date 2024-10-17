using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{ 
    public static LevelManager main;
    public Transform[] caminhos; //onde o inimigo vai passar
    public Transform começo;// onde aparece o inimigo
<<<<<<< Updated upstream
=======
    public Transform final;

>>>>>>> Stashed changes
    private void Awake()
    {
        main = this;
    }
}
