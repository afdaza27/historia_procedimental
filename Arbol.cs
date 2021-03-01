using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol 
{
    Tipo tipo;
    float altura;
    Vector3 posInicial;
    GameObject arbol;
    int minAltura = 8, maxAltura = 20;
    GameObject tronco;
    float radioTronco = 2;
    int minRadioCopa = 5, maxRadioCopa = 10;
    int minRadioCono = 4, maxRadioCono = 8;
    float minAlturaCono = 8, maxAlturaCono = 16;
    Color[] coloresHoja = new Color[] {Color.green };
    Color colorTronco = new Color(0.396f, 0.2627f, 0.1294f);
    enum Tipo
    {
        REDONDO,
        CONO
    }

    public Arbol(Vector3 posicion, int tipo)
    {
        posInicial = posicion;
        if(tipo == 1)
        {
            this.tipo = Tipo.CONO;
        }
        else
        {
            this.tipo = Tipo.REDONDO;
        }
        arbol = new GameObject("Arbol");
        arbol.transform.position = posInicial;
        altura = Random.Range(minAltura, maxAltura + 1);
    }


    public void DibujarArbol()
    {
        tronco = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tronco.transform.parent = arbol.transform;
        tronco.name = "Tronco";
        tronco.transform.localPosition = new Vector3(0, altura / 2, 0);
        tronco.transform.localScale = new Vector3(radioTronco * 2, altura / 2, radioTronco*2) ;
        tronco.GetComponent<MeshRenderer>().material.color = colorTronco;
        if(tipo == Tipo.CONO)
        {
            DibujarArbolEsferico();
        }
        else
        {
            DibujarArbolCono();
        }
    }

    private void DibujarArbolEsferico()
    {
        GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        int radio = Random.Range(minRadioCopa, maxRadioCopa+1);
        esfera.name = "Copa";
        esfera.transform.parent = arbol.transform;
        esfera.transform.localPosition = new Vector3(0, altura + radio, 0);
        esfera.transform.localScale = new Vector3(2 * radio, 2 * radio, 2 * radio);
        esfera.GetComponent<MeshRenderer>().material.color = coloresHoja[Random.Range(0, coloresHoja.Length)];
    }

    private void DibujarArbolCono()
    {
        GameObject coneObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        coneObject.AddComponent<Cone>();
        Cone cone = coneObject.GetComponent<Cone>();
        cone.Altura = Random.Range(minAlturaCono, maxAlturaCono);
        cone.Radio = Random.Range(minRadioCono, maxRadioCono + 1);
        cone.PosInicial = new Vector3(posInicial.x, posInicial.y + altura, posInicial.z);
        cone.DibujarCono();
        cone.GetComponent<MeshRenderer>().material.color = coloresHoja[Random.Range(0, coloresHoja.Length)];
        coneObject.transform.parent = arbol.transform;
        coneObject.name = "Copa";
    }

}
