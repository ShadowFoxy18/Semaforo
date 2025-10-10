using UnityEngine;

public class SemaforoColor : MonoBehaviour
{
    [SerializeField]
    GameObject[] luces;

    [SerializeField]
    Material[] materiales;

    [SerializeField]
    float[] timeLuces;

    public float porcentajeProximidad = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material colorApagado = materiales[0];
        foreach (var luz in luces)
        {
            luz.mr.material = colorApagado;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
