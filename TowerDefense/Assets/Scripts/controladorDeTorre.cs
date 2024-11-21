using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeTorre : MonoBehaviour
{
    private Dictionary<GameObject, bool> quadrados = new Dictionary<GameObject, bool>();

    void Start()
    {
        GameObject[] todosQuadrados = GameObject.FindGameObjectsWithTag("Quadrado");
        foreach (GameObject q in todosQuadrados)
        {
            quadrados.Add(q, false); // Marca todos os quadrados como desocupados
        }
    }

    public bool QuadradoOcupado(GameObject quadrado)
    {
        return quadrados[quadrado];
    }

    public void ColocarTorre(GameObject quadrado, GameObject torrePrefab)
    {
        Instantiate(torrePrefab, quadrado.transform.position, Quaternion.identity);
        quadrados[quadrado] = true; // Marca o quadrado como ocupado
    }

}
