using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso
{
    GameObject piso;
    Color colorPiso = new Color(0.12f, 0.4f, 0.18f);

    public void DibujarPiso()
    {
        piso = GameObject.CreatePrimitive(PrimitiveType.Plane);
        piso.transform.localScale = new Vector3(200, 1, 500);
        piso.GetComponent<MeshRenderer>().material.color = colorPiso;
        piso.name = "Piso";
    }
}
