using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangulos;
    Vector3 posInicial = new Vector3(0,0,0);
    float altura = 5;
    float radio = 4;
    int numeroBordes = 80;


    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    public int NumeroBordes
    {
        set { this.numeroBordes = value; }
    }

    public float Radio
    {
        set { this.radio = value; }
    }

    public float Altura
    {
        set { this.altura = value; }
    }

    public Vector3 PosInicial
    {
        set { this.posInicial = value; }
    }

    public void DibujarCono()
    {
        vertices = new List<Vector3>();
        triangulos = new List<int>();
        GenerarDatos();
        InicializarMesh();
    }

    private void GenerarDatos()
    {
        vertices.Add(new Vector3(posInicial.x, posInicial.y + altura, posInicial.z));
        vertices.Add(posInicial);
        float angulo = 0;
        float incremento_angulo = (2 * Mathf.PI) / numeroBordes;
        for(int i = 0; i < numeroBordes;i++)
        {
            vertices.Add(new Vector3(posInicial.x + radio * Mathf.Cos(angulo), posInicial.y, posInicial.z + radio * Mathf.Sin(angulo)));
            angulo += incremento_angulo;
        }

        //triangulos de la base
        int indice_centro = 1;
        int siguiente = 2;
        for (int i = 0; i < numeroBordes-1; i ++)
        {
            triangulos.Add(indice_centro);
            triangulos.Add(siguiente);
            triangulos.Add(siguiente + 1);
            siguiente++;
        }
        triangulos.Add(indice_centro);
        triangulos.Add(siguiente);
        triangulos.Add(2);

        int indice_punta = 0;
        siguiente = 2;
        for(int j = 0; j < numeroBordes - 1; j++)
        {
            triangulos.Add(indice_punta);
            triangulos.Add(siguiente + 1);
            triangulos.Add(siguiente);
            siguiente++;
        }
        triangulos.Add(indice_punta);
        triangulos.Add(2);
        triangulos.Add(siguiente);

    }

    private void InicializarMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangulos.ToArray();
        mesh.RecalculateNormals();
    }

    
}
