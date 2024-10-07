using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D corpo;
    [SerializeField] private float velocidade = 1f;

    private Transform objetivo;
    private int caminhoIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = LevelManager.main.caminhos[caminhoIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(objetivo.position, transform.position) < velocidade) { }
    }
}
