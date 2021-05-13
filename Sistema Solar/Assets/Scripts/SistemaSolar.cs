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
    Vector3 VelPlaneta3;
    Vector3 VelPlaneta4;
    Vector3 VelPlaneta5;
    Vector3 VelPlaneta6;
    Vector3 VelPlaneta7;
    Vector3 VelPlaneta8;
    Vector3 VelPlaneta9;
    float m1, m2, m3, m4, m5, m6, m7, m8, m9;
    Vector3 PosPlaneta1;
    Vector3 PosPlaneta2;
    Vector3 PosPlaneta3;
    Vector3 PosPlaneta4;
    Vector3 PosPlaneta5;
    Vector3 PosPlaneta6;
    Vector3 PosPlaneta7;
    Vector3 PosPlaneta8;
    Vector3 PosPlaneta9;
    Vector3 Fuerza1;
    Vector3 Fuerza2;
    Vector3 Fuerza3;
    Vector3 Fuerza4;
    Vector3 Fuerza5;
    Vector3 Fuerza6;
    Vector3 Fuerza7;
    Vector3 Fuerza8;
    Vector3 Fuerza9;
    Vector3 auxVel;
    Vector3 auxPos;
    // Update is called once per frame
    void Update()
    {
            //planetas[0] = Jupiter
            //planetas[1] = Saturno
            //planetas[2] = Tierra
            //planetas[3] = Urano
            //planetas[4] = Neptuno
            //planetas[5] = Marte
            //planetas[6] = Sol
            //planetas[7] = Mercurio
            //planetas[8] = Venus
            //Obtención de Variables:
            PosPlaneta9 = planetas[4].GetComponent<Planeta>().get_Posicion();
            PosPlaneta8 = planetas[3].GetComponent<Planeta>().get_Posicion();
            PosPlaneta7 = planetas[1].GetComponent<Planeta>().get_Posicion();
            PosPlaneta6 = planetas[0].GetComponent<Planeta>().get_Posicion();
            PosPlaneta5 = planetas[5].GetComponent<Planeta>().get_Posicion();
            PosPlaneta4 = planetas[8].GetComponent<Planeta>().get_Posicion();
            PosPlaneta3 = planetas[7].GetComponent<Planeta>().get_Posicion();
            PosPlaneta1 = planetas[2].GetComponent<Planeta>().get_Posicion();
            PosPlaneta2 = planetas[6].GetComponent<Planeta>().get_Posicion();
            VelPlaneta9 = planetas[4].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta8 = planetas[3].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta7 = planetas[1].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta6 = planetas[0].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta5 = planetas[5].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta4 = planetas[8].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta3 = planetas[7].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta1 = planetas[2].GetComponent<Planeta>().get_Velocidad();
            VelPlaneta2 = planetas[6].GetComponent<Planeta>().get_Velocidad();
            m9 = planetas[4].GetComponent<Planeta>().get_Masa();
            m8 = planetas[3].GetComponent<Planeta>().get_Masa();
            m7 = planetas[1].GetComponent<Planeta>().get_Masa();
            m6 = planetas[0].GetComponent<Planeta>().get_Masa();
            m5 = planetas[5].GetComponent<Planeta>().get_Masa();
            m4 = planetas[8].GetComponent<Planeta>().get_Masa();
            m3 = planetas[7].GetComponent<Planeta>().get_Masa();
            m1 = planetas[2].GetComponent<Planeta>().get_Masa();
            m2 = planetas[6].GetComponent<Planeta>().get_Masa();
            Debug.Log(planetas[7]);
            
            //Calculos de la fuerza Tierra  - Sol (Como el calculo es tierra sol, la Posición de la tierra es el parametro 1)
            Fuerza1 = planetas[2].GetComponent<Planeta>().fuerzaG(PosPlaneta1, PosPlaneta2, G, m1, m2);

            eulerSolver(paso, Fuerza1, PosPlaneta1, VelPlaneta1, m1);
        
            planetas[2].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[2].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[2].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Sol - Tierra (Como el calculo es sol tierra, la Posición del Sol es el parametro 1)
            Fuerza2 = planetas[6].GetComponent<Planeta>().fuerzaG(PosPlaneta2, PosPlaneta1, G, m2, m1);

            eulerSolver(paso, Fuerza2, PosPlaneta2, VelPlaneta2, m2);

            planetas[6].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[6].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[6].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Mercurio  - Sol
            Fuerza3 = planetas[7].GetComponent<Planeta>().fuerzaG(PosPlaneta3, PosPlaneta2, G, m3, m2);

            eulerSolver(paso, Fuerza3, PosPlaneta3, VelPlaneta3, m3);
        
            planetas[7].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[7].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[7].GetComponent<Planeta>().cargarPosicion();

            
            //Calculos de la fuerza Venus  - Sol
            Fuerza4 = planetas[8].GetComponent<Planeta>().fuerzaG(PosPlaneta4, PosPlaneta2, G, m4, m2);

            eulerSolver(paso, Fuerza4, PosPlaneta4, VelPlaneta4, m4);
        
            planetas[8].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[8].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[8].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Marte  - Sol
            Fuerza5 = planetas[5].GetComponent<Planeta>().fuerzaG(PosPlaneta5, PosPlaneta2, G, m5, m2);

            eulerSolver(paso, Fuerza5, PosPlaneta5, VelPlaneta5, m5);
        
            planetas[5].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[5].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[5].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Jupiter  - Sol
            Fuerza6 = planetas[0].GetComponent<Planeta>().fuerzaG(PosPlaneta6, PosPlaneta2, G, m6, m2);

            eulerSolver(paso, Fuerza6, PosPlaneta6, VelPlaneta6, m6);
        
            planetas[0].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[0].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[0].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Saturno  - Sol
            Fuerza7 = planetas[1].GetComponent<Planeta>().fuerzaG(PosPlaneta7, PosPlaneta2, G, m7, m2);

            eulerSolver(paso, Fuerza7, PosPlaneta7, VelPlaneta7, m7);
        
            planetas[1].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[1].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[1].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Urano - Sol
            Fuerza8 = planetas[3].GetComponent<Planeta>().fuerzaG(PosPlaneta8, PosPlaneta2, G, m8, m2);

            eulerSolver(paso, Fuerza8, PosPlaneta8, VelPlaneta8, m8);
        
            planetas[3].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[3].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[3].GetComponent<Planeta>().cargarPosicion();

            //Calculos de la fuerza Neptuno - Sol
            Fuerza9 = planetas[4].GetComponent<Planeta>().fuerzaG(PosPlaneta9, PosPlaneta2, G, m9, m2);

            eulerSolver(paso, Fuerza9, PosPlaneta9, VelPlaneta9, m9);
        
            planetas[4].GetComponent<Planeta>().set_Posicion(auxPos);
            planetas[4].GetComponent<Planeta>().set_Velocidad(auxVel);
            planetas[4].GetComponent<Planeta>().cargarPosicion();

            
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
