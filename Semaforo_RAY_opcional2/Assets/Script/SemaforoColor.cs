using UnityEngine;

public class SemaforoColor : MonoBehaviour
{
    //Array de las luces que se cambian: roja, narnaja, verde
    [SerializeField]
    GameObject[] luces;

    //Array de los materiales de 4 luces: luzApagada, luzRoja, luzNaranja, luzVerde
    [SerializeField]
    Material[] materiales;

    //tiempo que dura cada luz: roja, naranja, verde
    [SerializeField]
    float[] timeLuces;

    float timeTotal;

    //float de una proxiidad a los numeros antes mencionados
    public float porcentajeProximidad = 0.5f;

    public int repeticiones = 3;

    private Renderer[] renderers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderers = new Renderer[luces.Length];
        //MeshRenderer mr = GetComponent<MeshRenderer>();
        Material colorApagado = materiales[0];
        for (int i = 0; i < luces.Length; i++)
        {
            renderers[i] = luces[i].GetComponent<Renderer>();
            renderers[i].material = colorApagado;
            timeTotal += Tiempo(timeLuces[i]);
        }
    }


    /// <summary>
    /// Creador de tiempo random desde un numero a otro con el porcentaje
    /// </summary>
    /// <param name="tiempo"></param>
    /// <returns></returns>
    float Tiempo(float tiempo)
    {
        float minTiempo = tiempo * porcentajeProximidad;
        float tiempoRandom = Random.Range(minTiempo, tiempo);
        return tiempoRandom;
    }



    
    /// <summary>
    /// Cambia la luz en funcion a lo que pida
    /// </summary>
    /// <param name="luz"></param>
    /// <param name="material"></param>
    public void CambiarLuz(int bombilla, int luz)
    {
        for (int i = 0; i < luces.Length; i++)
        {
            renderers[i].material = materiales[0];
        }
        renderers[bombilla].material = materiales[luz];
    }



    
    // Update is called once per frame
    void Update()
    {
        timeTotal -= Time.deltaTime;
        Debug.Log(timeTotal);
        //verde
        if (10 < timeTotal && timeTotal < 20) CambiarLuz(2, 3);
        
        //naranja
        if (6 < timeTotal && timeTotal < 9) CambiarLuz(1, 2);

        //rojo
        if (timeTotal < 5) CambiarLuz(0, 1);
    }
}
