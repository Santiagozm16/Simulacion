using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    [SerializeField] public Vector3 Posicion_Inicial; //Vector para inicializar desde unity
    public float masa; //Variable para la masa del planeta
    [SerializeField] public Vector3 Velocidad_Inicial; //Vector para inicializar desde unity

    public Vector3 Posicion; //Vector de Posición
    public Vector3 Velocidad; //Vector de Velocidad
    private Vector3 fuerzaNeta; //Fuerza Neta

    public Transform target; //Objeto sobre el cual rotar
    public int Rotacion; //Velocidad de la rotación
    void Update()
    {

        transform.RotateAround(target.transform.position, target.transform.up, Rotacion * Time.deltaTime); //Totación por cada frame
    }

    public Vector3 fuerzaG(Vector3 p1, Vector3 p2, float G, float m1, float m2)//Calculo de Fuerza gravitacional.
    {
        Vector3 r_vec = p1 - p2;
        float r_mag = r_vec.magnitude;
        Vector3 r_uni = r_vec / r_mag;
        float F_Esc = G * m1 * m2 / Mathf.Pow(r_mag, 2);
        Vector3 F = -F_Esc * r_uni;
        fuerzaNeta = F;
        return F;
    }

    //Get y Set del Planeta
    public void cargarPosicion()
    {
        transform.position = Posicion;
    }

    void Start()
    {
        Posicion = Posicion_Inicial;
        Velocidad = Velocidad_Inicial;
    }

    public Vector3 get_Posicion()
    {
        return Posicion;
    }

    public Vector3 get_Velocidad()
    {
        return Velocidad;
    }
    
    public void set_Posicion(Vector3 aux)
    {
        Posicion = aux;
    }
    public void set_Velocidad(Vector3 aux)
    {
        Velocidad = aux;
    }
    public float get_Masa()
    {
        return masa;
    }
}
