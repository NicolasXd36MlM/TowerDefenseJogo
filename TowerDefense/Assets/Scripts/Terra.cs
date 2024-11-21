using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra : MonoBehaviour
{
    public GameObject torrePrefab; // Prefab da torre
    public controladorDeTorre controladorDeTorre; // Gerencia o estado dos quadrados

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Quadrado"))
            {
                Instantiate(torrePrefab, hit.collider.transform.position, Quaternion.identity);
            }
        }
        
    }

    public GameObject DetectarQuadrado(Vector2 posicao)
    {
        RaycastHit2D hit = Physics2D.Raycast(posicao, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Quadrado"))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
