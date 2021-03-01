using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElonMusk
{
    float radioCabeza = 0.5f;
    float alturaTorso = 2;
    float anchoTorso = 1.5f;
    float profundidadTorso = 0.5f;
    float radioPiernas = 0.25f;
    float radioBrazos = 0.25f;
    float largoPiernas = 2;
    float largoBrazos = 1.5f;
    Vector3 posInicial = new Vector3(0,0,0);
    GameObject elonMusk;
    Color[] coloresPiel;
    Color[] coloresTorso;
    Color[] coloresPantalon;
    Color colorPiel;
    GameObject brazoDerecho;
    GameObject brazoIzquierdo;
  
    

    public ElonMusk(Vector3 posicion)
    {
        posInicial = posicion;
        elonMusk = new GameObject("Elon Musk");
        elonMusk.transform.position = posInicial;
        coloresPiel = new Color[] { new Color(0.9764f, 0.847f, 0.9568f), new Color(0.75294f, 0.4745f, 0.2431f), Color.gray};
        coloresTorso = new Color[] { Color.blue, Color.red, Color.green, Color.yellow, Color.magenta };
        coloresPantalon = new Color[] { new Color(0, 0, 0.6078f), Color.black, new Color(0.3215f, 0.2509f, 0.1294f) };
        colorPiel = coloresPiel[Random.Range(0, coloresPiel.Length)];
    }

    public void DibujarElonMusk()
    {
        DibujarCabeza();
        DibujarTorso();
        DibujarPiernas();
        DibujarBrazos();
    }

    public void AgregarAnimaciones()
    {
        elonMusk.AddComponent<AnimacionSalto>();
        //brazoIzquierdo.AddComponent<AnimacionBrazos>();
    }

    public void DibujarCabeza()
    {
        GameObject cabeza = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        cabeza.transform.parent = elonMusk.transform;
        cabeza.name = "Cabeza";
        cabeza.transform.localPosition = new Vector3(posInicial.x, posInicial.y + largoPiernas + alturaTorso + radioCabeza, posInicial.z);
        cabeza.transform.localScale = new Vector3(radioCabeza*2, radioCabeza*2, radioCabeza*2);
        cabeza.GetComponent<MeshRenderer>().material.color = colorPiel;
    }

    public void DibujarTorso()
    {
        GameObject torso = GameObject.CreatePrimitive(PrimitiveType.Cube);
        torso.transform.parent = elonMusk.transform;
        torso.name = "Torso";
        torso.transform.localPosition = new Vector3(posInicial.x, posInicial.y + largoPiernas + alturaTorso/2, posInicial.z);
        torso.transform.localScale = new Vector3(anchoTorso, alturaTorso, profundidadTorso);
        torso.GetComponent<MeshRenderer>().material.color = coloresTorso[Random.Range(0, coloresTorso.Length)];
    }

    public void DibujarPiernas()
    {
        GameObject piernaDerecha = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        piernaDerecha.transform.parent = elonMusk.transform;
        piernaDerecha.name = "Pierna Derecha";
        piernaDerecha.transform.localPosition = new Vector3(posInicial.x - anchoTorso/2 + radioPiernas, posInicial.y + largoPiernas/2, posInicial.z);
        piernaDerecha.transform.localScale = new Vector3(radioPiernas*2,largoPiernas/2, radioPiernas *2);
        Color colorPantalon = coloresPantalon[Random.Range(0, coloresPantalon.Length)];
        piernaDerecha.GetComponent<MeshRenderer>().material.color = colorPantalon;

        GameObject piernaIzquierda = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        piernaIzquierda.transform.parent = elonMusk.transform;
        piernaIzquierda.name = "Pierna Izquierda";
        piernaIzquierda.transform.localPosition = new Vector3(posInicial.x + anchoTorso / 2 - radioPiernas, posInicial.y + largoPiernas / 2, posInicial.z);
        piernaIzquierda.transform.localScale = new Vector3(radioPiernas * 2, largoPiernas / 2, radioPiernas * 2);
        piernaIzquierda.GetComponent<MeshRenderer>().material.color = colorPantalon;

    }

    public void DibujarBrazos()
    {
        float angulo;
        int inclinacion = Random.Range(1, 3);
        if(inclinacion == 1)
        {
            angulo = 50;
        }
        else
        {
            angulo = 310;
        }
       
        float anguloRad = angulo * Mathf.Deg2Rad;
        
        brazoIzquierdo = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        brazoIzquierdo.transform.parent = elonMusk.transform;
        brazoIzquierdo.name = "Brazo Izquierdo";
        Vector3 posicionHombroIzquierdo = new Vector3(posInicial.x - anchoTorso, posInicial.y + largoPiernas + alturaTorso - 0.2f, posInicial.z);
        brazoIzquierdo.transform.Rotate(new Vector3(0, 0, angulo));
        brazoIzquierdo.transform.localPosition = new Vector3(posicionHombroIzquierdo.x+(largoBrazos/4)*Mathf.Cos(anguloRad), posicionHombroIzquierdo.y + (largoBrazos /4) * Mathf.Sin(anguloRad), posicionHombroIzquierdo.z);
        brazoIzquierdo.transform.localScale = new Vector3(radioBrazos*2, largoBrazos/2, radioBrazos*2);
        brazoIzquierdo.GetComponent<MeshRenderer>().material.color = colorPiel;


        if (inclinacion == 1)
        {
            angulo = 130;
        }
        else
        {
            angulo = 230;
        }
        anguloRad = angulo * Mathf.Deg2Rad;
        brazoDerecho = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        brazoDerecho.transform.parent = elonMusk.transform;
        brazoDerecho.name = "Brazo Derecho";
        Vector3 posicionHombroDerecho = new Vector3(posInicial.x + anchoTorso, posInicial.y + largoPiernas + alturaTorso - 0.2f, posInicial.z);
        brazoDerecho.transform.RotateAround(posicionHombroDerecho, new Vector3(0, 0, 1), angulo);
        brazoDerecho.transform.localPosition = new Vector3(posicionHombroDerecho.x+ (largoBrazos / 4) * Mathf.Cos(anguloRad), posicionHombroDerecho.y + (largoBrazos / 4) * Mathf.Sin(anguloRad), posicionHombroDerecho.z);
        brazoDerecho.transform.localScale = new Vector3(radioBrazos * 2, largoBrazos / 2, radioBrazos * 2);
        brazoDerecho.GetComponent<MeshRenderer>().material.color = colorPiel;
    }

}

