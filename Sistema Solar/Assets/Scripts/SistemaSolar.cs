using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSolar : MonoBehaviour
{
    public GameObject[] planetas;

    [SerializeField] float paso = 0f;
    [SerializeField] float G = 0f;

    // Start is called before the first frame update
    void Start()
    {
        planetas = GameObject.FindGameObjectsWithTag("Player");
    }
    //Variables Auxiliares para los calculos necesarios
    Vector3 VelPlaneta1;
    Vector3 VelPlaneta2;
    float m1, m2;
    Vector3 PosPlaneta1;
    Vector3 PosPlaneta2;
    Vector3 Fuerza1;
    Vector3 Fuerza2;
    Vector3 auxVel;
    Vector3 auxPos;
    // Update is called once per frame
    void Update()
    {
            //planetas[0] = La tierra
            //planetas[1] = El Sol
            //Obtención de Variables:
            PosPlaneta1 = planetas[0].GetComponent<Planeta>().get_Posicion();
            PosPlaneta2 = planetas[1].GetComponent<Planeta>().get_Posicion();
            VelPlaneta1 = planetas[0].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta2 = planetas[1].GetComponent<Planeta>().get_Velocidad();
            m1 = planetas[0].GetComponent<Planeta>().get_Masa();
            m2 = planetas[1].GetComponent<Planeta>().get_Masa();
            
            //Calculos de la fuerza Tierra  - Sol (Como el calculo es tierra sol, la Posición de la tierra es el parametro 1)
            Fuerza1 = planetas[0].GetComponent<Planeta>().fuerzaG(PosPlaneta1, PosPlaneta2, G, m1, m2);

            eulerSolver(paso, Fuerza1, PosPlaneta1, VelPlaneta1, m1);
        
            planetas[0].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[0].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[0].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Sol - Tierra (Como el calculo es sol tierra, la Posición del Sol es el parametro 1)
            Fuerza2 = planetas[1].GetComponent<Planeta>().fuerzaG(PosPlaneta2, PosPlaneta1, G, m2, m1);

            eulerSolver(paso, Fuerza2, PosPlaneta2, VelPlaneta2, m2);

            planetas[1].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[1].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[1].GetComponent<Planeta>().cargarPosicion();
    }

    public void eulerSolver(float step, Vector3 Fuerza, Vector3 p, Vector3 v, float mass) //Solucionador de Euler 
    {
        Vector3 aceleracion = Fuerza / mass;
        Vector3 velPasada = v;
        v += aceleracion * step;
        p += velPasada * step;

        auxVel = v;
        auxPos = p;
    }
}
