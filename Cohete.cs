using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohete
{
    const int AlturaPropulsor = 10;
    const int AlturaCuerpo = 50;
    const int AlturaPunta = 20;
    const int RadioCohete = 10;
    const int RadioVentana = 4;
    const int RadioPropulsor = 8;
    const int numeroAlas = 4;
    Cone cone;
    Cone propulsor;
    Cone fuego;
    AlaCohete ala1;
    Vector3 posInicial = new Vector3(0,0,0);
    GameObject cohete;
    Color colorPunta = new Color(0.8f, 0.24f, 0.24f);
    Color colorCuerpo = Color.white;
    Color colorPropulsor = new Color(0.2f, 0.2f, 0.2f);
    Color colorVentana = new Color(0.168f, 0.4549f, 0.949f);

    public Cohete(Vector3 posicion)
    {
        posInicial = posicion;
        cohete = new GameObject("Cohete");
        cohete.transform.position = posInicial;
    }
    // Start is called before the first frame update
    public void DibujarCohete()
    {
        DibujarPunta();
        DibujarCuerpo();
        DibujarPropulsor();
        DibujarAlas();
        DibujarVentana();
    }

    public void AgregarAnimaciones()
    {
        cohete.AddComponent<AnimacionCohete>();
    }

    private void DibujarPunta()
    {
        GameObject coneObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        coneObject.AddComponent<Cone>();
        cone = coneObject.GetComponent<Cone>();
        cone.Altura = AlturaPunta;
        cone.Radio = RadioCohete;
        cone.PosInicial = new Vector3(posInicial.x, posInicial.y + AlturaCuerpo + AlturaPropulsor, posInicial.z);
        cone.DibujarCono();
        cone.GetComponent<MeshRenderer>().material.color = colorPunta;
        coneObject.transform.parent = cohete.transform;
        coneObject.name = "Punta";
    }

    private void DibujarCuerpo()
    {
        GameObject cuerpo = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cuerpo.transform.parent = cohete.transform;
        cuerpo.name = "Cuerpo";
        cuerpo.transform.localPosition = new Vector3(0, AlturaPropulsor + (AlturaCuerpo / 2), 0);
        cuerpo.transform.localScale = new Vector3(RadioCohete*2, AlturaCuerpo/2, RadioCohete*2);
        cuerpo.GetComponent<MeshRenderer>().material.color = colorCuerpo;
    }

    private void DibujarPropulsor()
    {
        GameObject propulsorObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        propulsorObject.AddComponent<Cone>();
        propulsor = propulsorObject.GetComponent<Cone>();
        propulsor.Altura = AlturaPropulsor + 10;
        propulsor.Radio = RadioPropulsor;
        propulsor.PosInicial = new Vector3(posInicial.x, posInicial.y, posInicial.z);
        propulsor.DibujarCono();
        propulsor.GetComponent<MeshRenderer>().material.color = colorPropulsor;
        propulsorObject.transform.parent = cohete.transform;
        propulsorObject.name = "Propulsor";

        GameObject fueginho = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fueginho.AddComponent<Cone>();
        fuego = fueginho.GetComponent<Cone>();
        fuego.Altura = AlturaPropulsor + 10;
        fuego.Radio = RadioPropulsor-2;
        fuego.PosInicial = new Vector3(posInicial.x, posInicial.y-20, posInicial.z);
        fuego.DibujarCono();
        fuego.GetComponent<MeshRenderer>().material.color = new Color(1,0.647f,0);
        fueginho.transform.parent = cohete.transform;
        fueginho.transform.Rotate(new Vector3(-180, 0, 0));
        fueginho.AddComponent<AnimacionFuego>();
        fueginho.name = "Fuego";
    }

    private void DibujarAlas()
    {
        GameObject alaObject = null;
        float angulo = 0;
        float incrementoAngulo = (360 / numeroAlas) * Mathf.Deg2Rad;
        for(int i = 0; i < numeroAlas; i++)
        {
            Vector3 posicionAla = new Vector3(posInicial.x - RadioCohete* Mathf.Cos(angulo), posInicial.y + AlturaPropulsor + 25, posInicial.z +RadioCohete * Mathf.Sin(angulo) );
            alaObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            alaObject.AddComponent<AlaCohete>();
            ala1 = alaObject.GetComponent<AlaCohete>();
            ala1.PosInicial = posicionAla;
            ala1.DibujarAla();
            ala1.GetComponent<MeshRenderer>().material.color = colorPunta;
            ala1.transform.parent = cohete.transform;
            ala1.name = "Ala "+(i+1);
            alaObject.transform.RotateAround(new Vector3(posicionAla.x, posicionAla.y, posicionAla.z), new Vector3(0,1,0), angulo*Mathf.Rad2Deg);
            angulo += incrementoAngulo;
        }
    }
    private void DibujarVentana()
    {
        GameObject ventana = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ventana.transform.parent = cohete.transform;
        ventana.name = "Ventana";
        ventana.transform.localPosition = new Vector3(0, AlturaPropulsor + (AlturaCuerpo / 2) + 15, 0);
        ventana.transform.localScale = new Vector3(RadioVentana * 2, RadioCohete, RadioVentana * 2);
        ventana.transform.Rotate(new Vector3(0, 90, 90));
        ventana.GetComponent<MeshRenderer>().material.color = colorVentana;
    }
}
