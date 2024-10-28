using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer terra;
    [SerializeField]
    private Color CorCampo;

    private GameObject torre;
    private Color CorPrimaria;

    private void Start()
    {
        CorPrimaria = terra.color;
    }
    private void OnMouseEnter()
    {
        terra.color = CorCampo;
    }

    private void OnMouseExit()
    {
        terra.color = CorPrimaria;
    }

    private void OnMouseDown()
    {
        Debug.Log("construa uma torre aqui: " + name);
    }
}
