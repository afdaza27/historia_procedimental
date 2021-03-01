using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna
{
    float radio = 40;
    Vector3 posInicial;
    GameObject luna;
    Color colorLuna = new Color(0.54f, 0.5607f, 0.5921f);

    public Luna(Vector3 posicion)
    {
        posInicial = posicion;
    }

    public void DibujarLuna()
    {
        luna = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        luna.name = "Luna";
        luna.transform.position = posInicial;
        luna.transform.localScale = new Vector3(radio * 2, radio * 2, radio * 2);
        luna.GetComponent<MeshRenderer>().material.color = colorLuna;
    }
}
