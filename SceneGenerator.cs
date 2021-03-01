using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    //Cohete
    Cohete cohete;
    Vector3 posicionCohete = new Vector3(-10, 20, 0);

    //Base de lanzamiento
    Vector3 posicionBase = new Vector3(0, 0, 0);
    BaseLanzamiento baseLanzamiento;

    //Luna
    Luna luna;
    Vector3 posicionLuna = new Vector3(0, 422, 540);

    //Publico
    List<ElonMusk> publico;
    int filas = 10, columnas = 16;
    Vector3 posInicialPublico = new Vector3(-40, 0, -20);
    float separacion = 5;

    //Satelite
    Satelite satelite;
    Vector3 posInicialSatelite = new Vector3(-154,220,160);

    //Piso
    Piso piso;

    //Arboles
    Arbol[] arboles;
    int numArboles = 150;
    float minSpawnArbolX = -250, maxSpawnArbolX = 250;
    float minSpawnArbolZ = 50, maxSpawnArbolZ = 250;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.localPosition = new Vector3(111, 101, -307);
        Camera.main.transform.Rotate(new Vector3(0,-10,0));
        Camera.main.gameObject.AddComponent<AnimacionCamara>();
        //Dibujar cohete
        cohete = new Cohete(posicionCohete);
        cohete.DibujarCohete();
        //Animar cohete
        cohete.AgregarAnimaciones();

        //Dibujar base de lanzamiento
        baseLanzamiento = new BaseLanzamiento(posicionBase);
        baseLanzamiento.DibujarBaseLanzamiento();

        //Dibujar luna
        luna = new Luna(posicionLuna);
        luna.DibujarLuna();

        //Inicializar y dibujar publico
        publico = new List<ElonMusk>();
        DibujarPublico();

        //Dibujar satelite
        satelite = new Satelite(posInicialSatelite);
        satelite.DibujarSatelite();

        //Dibujar piso
        piso = new Piso();
        piso.DibujarPiso();

        //Dibujar arboles
        arboles = new Arbol[numArboles];
        DibujarArboles();
    }

    private void DibujarPublico()
    {
        Vector3 posicionActual = posInicialPublico;
        float desvioX = Random.Range(-separacion / 2, separacion / 2);
        float desvioZ = Random.Range(-separacion / 2, separacion / 2);
        Vector3 posicionPersona = new Vector3(posicionActual.x + desvioX, posicionActual.y, posicionActual.z + desvioZ);
        for (int i = 0; i < filas; i++)
        {
            publico.Add(new ElonMusk(posicionPersona));
            for(int j = 0; j < columnas; j++)
            {
                posicionActual.x += separacion;
                desvioX = Random.Range(-separacion / 2, separacion / 2);
                desvioZ = Random.Range(-separacion / 2, separacion / 2);
                posicionPersona = new Vector3(posicionActual.x + desvioX, posicionActual.y, posicionActual.z + desvioZ);
                publico.Add(new ElonMusk(posicionPersona));
            }
            posicionActual.z -= separacion;
            posicionActual.x = posInicialPublico.x;
        }
        foreach(ElonMusk elon in publico)
        {
            elon.DibujarElonMusk();
            elon.AgregarAnimaciones();
        }
        
    }

    private void DibujarArboles()
    {
        for(int i = 0; i < arboles.Length; i++)
        {
            float posX = Random.Range(minSpawnArbolX, maxSpawnArbolX);
            float posZ = Random.Range(minSpawnArbolZ, maxSpawnArbolZ);
            int tipo = Random.Range(1, 3);
            Arbol arbol = new Arbol(new Vector3(posX, 0, posZ), tipo);
            arbol.DibujarArbol();
            arboles[i] = arbol;
        }
    }
}
