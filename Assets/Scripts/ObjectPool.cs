using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --------------------------------------
// SCRIPT PARA EL OBJECT POOL
// --------------------------------------
public class ObjectPool : MonoBehaviour
{
    // Crearemos una clase singleton para manejar el Pool de Objetos
    public static ObjectPool instance;
    // Generamos la lista de objetos
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] int amountToPool = 20;
    // Objeto que guardaremos en el pool
    [SerializeField] GameObject bulletPrefab;
    // Para convertirlo en Singleton
    void Awake()
    {
        // Garantizamos que solo exista una instancia del ObjectPool
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
    }
    // M�todo que se ejecuta antes del primer frame
    void Start()
    {
        // Generamos todos los objetos
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab); // Instanciamos el objeto
            obj.SetActive(false); // Lo desactivamos
            pooledObjects.Add(obj); // A�adimos el objeto a la lista
        }
    }

    // --------------------------------------
    // M�TODO GET POOLED OBJECT
    // --------------------------------------
    public GameObject GetPooledObject()
    {
        // Recorremos el pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // Si el objeto no est� activo en la jerarqu�a quiere decir
            // que est� disponible para su uso
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; // Devolvemos el objeto disponible
            }
        }
        return null; // Si todos los objetos est�n ocupados devolvemos nulo
    }

}
