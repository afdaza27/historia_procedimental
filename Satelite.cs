using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite
{

    Vector3 posInicial = new Vector3(0,0,0);
    GameObject satelite;
    float largoCuerpo = 40;
    float radioCuerpo = 8;
    float largoAntena = 10;
    float radioAntena = 1;
    float largoPropulsor = 8;
    float radioPropulsor = 6;
    float anchoAlas = 50;
    float alturaAlas = 40;
    float profundidadAlas = 4;
    Color colorAlas = new Color(0.1098f, 0.16078f, 0.488f);
    Color colorCuerpo = new Color(0.4f, 0.4f, 0.4f);
    Color colorAntena = new Color(0.6705f, 0.6823f, 0.7529f);
    Color colorPropulsor = new Color(0.4901f, 0.498f, 0.5529f);

    public Satelite(Vector3 posicion)
    {
        posInicial = posicion;
        satelite = new GameObject("Satelite");
        satelite.transform.localPosition = posInicial;

        
    }

    public void DibujarSatelite()
    {
        DibujarCuerpo();
        DibujarAntena();
        DibujarPropulsor();
        DibujarAlas();
        satelite.transform.Rotate(new Vector3(120, 160,10));
    }

    private void DibujarCuerpo()
    {
        GameObject cuerpo = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cuerpo.name = "Cuerpo";
        cuerpo.transform.parent = satelite.transform;
        cuerpo.transform.localPosition = Vector3.zero;
        cuerpo.transform.localScale = new Vector3(radioCuerpo * 2, largoCuerpo / 2, radioCuerpo * 2);
        cuerpo.GetComponent<MeshRenderer>().material.color = colorCuerpo;
    }

    private void DibujarAntena()
    {
        GameObject antena = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        antena.name = "Antena";
        antena.transform.parent = satelite.transform;
        antena.transform.localPosition = new Vector3(0, largoCuerpo / 2 + largoAntena / 2, 0);
        antena.transform.localScale = new Vector3(radioAntena * 2, largoAntena / 2, radioAntena * 2);
        antena.GetComponent<MeshRenderer>().material.color = colorAntena;
    }

    private void DibujarPropulsor()
    {
        GameObject propulsor = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        propulsor.name = "Propulsor";
        propulsor.transform.parent = satelite.transform;
        propulsor.transform.localPosition = new Vector3(0,  - largoCuerpo / 2 - largoPropulsor / 2, 0);
        propulsor.transform.localScale = new Vector3(radioPropulsor * 2, largoPropulsor / 2, radioPropulsor * 2);
        propulsor.GetComponent<MeshRenderer>().material.color = colorPropulsor;
    }

    private void DibujarAlas()
    {
        GameObject alaDerecha = GameObject.CreatePrimitive(PrimitiveType.Cube);
        alaDerecha.name = "Ala Derecha";
        alaDerecha.transform.parent = satelite.transform;
        alaDerecha.transform.localPosition = new Vector3( radioCuerpo + anchoAlas / 2, 0, 0);
        alaDerecha.transform.localScale = new Vector3(anchoAlas, alturaAlas, profundidadAlas);
        alaDerecha.transform.Rotate(new Vector3(30, 0, 0));

        GameObject alaIzquierda = GameObject.CreatePrimitive(PrimitiveType.Cube);
        alaIzquierda.name = "Ala Izquierda";
        alaIzquierda.transform.parent = satelite.transform;
        alaIzquierda.transform.localPosition = new Vector3(- radioCuerpo - anchoAlas / 2, 0, 0);
        alaIzquierda.transform.localScale = new Vector3(anchoAlas, alturaAlas, profundidadAlas);
        alaIzquierda.transform.Rotate(new Vector3(30, 0, 0));

        alaDerecha.GetComponent<MeshRenderer>().material.color = colorAlas;
        alaIzquierda.GetComponent<MeshRenderer>().material.color = colorAlas;
    }

}
