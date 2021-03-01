using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLanzamiento
{
    Vector3 posInicial = new Vector3(0, 0, 0);
    GameObject baseLanzamiento;
    float anchoBase = 80;
    float alturaBase = 20;
    float profundidadBase = 30;
    float anchoElevador = 20;
    float alturaElevador = 70;
    float profundidadElevador = 20;
    float anchoPuente = 20;
    float alturaPuente = 5;
    float profundidadPuente = 10;
    Color colorBase = new Color(0.58f, 0.513f, 0.513f);
    Color colorElevador = new Color(0.58f, 0.24f, 0.24f);
    Color colorPuente = new Color(0.58f,0.24f, 0.24f);

    public BaseLanzamiento(Vector3 posicion)
    {
        posInicial = posicion;
        baseLanzamiento = new GameObject("Base Lanzamiento");
        baseLanzamiento.transform.position = posInicial;
    }

    public void DibujarBaseLanzamiento()
    {
        DibujarBase();
        DibujarElevador();
        DibujarPuente();
    }

    private void DibujarBase()
    {
        GameObject baseObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        baseObject.transform.parent = baseLanzamiento.transform;
        baseObject.name = "Base";
        baseObject.transform.localPosition = new Vector3(posInicial.x, posInicial.y + alturaBase / 2, posInicial.z);
        baseObject.transform.localScale = new Vector3(anchoBase, alturaBase, profundidadBase);
        baseObject.GetComponent<MeshRenderer>().material.color = colorBase;
    }

    private void DibujarElevador()
    {
        GameObject elevador = GameObject.CreatePrimitive(PrimitiveType.Cube);
        elevador.transform.parent = baseLanzamiento.transform;
        elevador.name = "Elevador";
        elevador.transform.localPosition = new Vector3(posInicial.x + (anchoBase/2)-(anchoElevador/2), posInicial.y + alturaBase + (alturaElevador/2), posInicial.z);
        elevador.transform.localScale = new Vector3(anchoElevador, alturaElevador, profundidadElevador);
        elevador.GetComponent<MeshRenderer>().material.color = colorElevador;
    }

    private void DibujarPuente()
    {
        float offsetPuente = 30;
        GameObject puente = GameObject.CreatePrimitive(PrimitiveType.Cube);
        puente.transform.parent = baseLanzamiento.transform;
        puente.name = "Puente";
        puente.transform.localPosition = new Vector3(posInicial.x + (anchoBase / 2) - anchoElevador - (anchoPuente/2), posInicial.y + alturaBase + alturaElevador - offsetPuente, posInicial.z);
        puente.transform.localScale = new Vector3(anchoPuente, alturaPuente, profundidadPuente);
        puente.GetComponent<MeshRenderer>().material.color = colorPuente;
    }
}
