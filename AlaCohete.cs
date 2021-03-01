using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlaCohete : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices;
    int[] triangulos;
    float ladoUno = 25;
    float ladoDos = 15;
    float ancho = 1;
    float angulo = 130 * Mathf.Deg2Rad;
    Vector3 posInicial = new Vector3(0, 0, 0);

    public float LadoUno
    {
        set { ladoUno = value; }
    }

    public float LadoDos
    {
        set { ladoDos = value; }
    }

    public float Ancho
    {
        set { ancho = value; }
    }

    public float Angulo
    {
        set { angulo = value; }
    }


    public Vector3 PosInicial
    {
        set { posInicial = value; }
    }


    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    public void DibujarAla()
    {
        vertices = new List<Vector3>();
        GenerarDatos();
        InicializarMesh();
    }

    private void GenerarDatos()
    {
        vertices.Add(posInicial);
        vertices.Add(new Vector3(posInicial.x, posInicial.y - ladoUno, posInicial.z));
        vertices.Add(new Vector3(posInicial.x - ladoDos * Mathf.Cos(angulo-(Mathf.PI/2)), posInicial.y - ladoUno - ladoDos * Mathf.Sin(angulo - (Mathf.PI / 2)), posInicial.z));
        Vector3 segundaCara = new Vector3(posInicial.x, posInicial.y, posInicial.z + ancho);
        vertices.Add(segundaCara);
        vertices.Add(new Vector3(segundaCara.x, segundaCara.y - ladoUno, segundaCara.z));
        vertices.Add(new Vector3(segundaCara.x - ladoDos * Mathf.Cos(angulo - (Mathf.PI / 2)), segundaCara.y - ladoUno - ladoDos * Mathf.Sin(angulo - (Mathf.PI / 2)), segundaCara.z));

        triangulos = new int[] {0,1,2,3,5,4,0,3,1,1,3,4,2,1,5,5,1,4,3,0,5,0,2,5 };

    }

    private void InicializarMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangulos;
        mesh.RecalculateNormals();
    }
}
