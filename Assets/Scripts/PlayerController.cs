using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] int bulletSpeed = 20;
    // Referencia al LineRenderer
    public LineRenderer rayoVisual;

    // Start is called before the first frame update
    void Start()
    {
        // Ocultamos el rayo
        rayoVisual.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Control de disparos
        if (Input.GetMouseButtonDown(0))
        {

            // Creamos el Raycast que apunte desde la cámara al centro de la pantalla
            Ray rayo = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;


            // -------------------------------------------------
            // Primero se verifica si el rayo ha golpeado algo
            // -------------------------------------------------
            if (Physics.Raycast(rayo, out hit))
            {

                // Obtener el punto de impacto del rayo visual
                Vector3 puntoImpacto = hit.point;

                // Mostrar el rayo desde la punta de la pistola hasta el lugar de impacto
                rayoVisual.enabled = true;
                rayoVisual.SetPosition(0, firePoint.position);
                rayoVisual.SetPosition(1, puntoImpacto);

                // Instanciar la bala y establecer su dirección hacia el punto de impacto
                //GameObject balaImpacto = Instantiate(bulletPrefab, firePoint);
                //balaImpacto.transform.SetParent(null);
                //Vector3 direccionImpacto = (puntoImpacto - firePoint.transform.position).normalized;
                //balaImpacto.GetComponent<Rigidbody>().velocity = direccionImpacto * bulletSpeed;

                // ----------------------------------------------------------------------------------
                // Utilizamos una bala del Object Pool (sustituye a la instanciación si hay impacto)
                // ----------------------------------------------------------------------------------
                GameObject bullet = ObjectPool.instance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position; // Colocamos el objeto en la posición
                    bullet.SetActive(true); // Activamos el objeto del pool
                    Vector3 direccionImpacto = (puntoImpacto - firePoint.transform.position).normalized;
                    bullet.GetComponent<Rigidbody>().velocity = direccionImpacto * bulletSpeed;
                }

            }
            else
            {

                // --------------------------------------------------------------
                // Si el rayo no ha golpeado nada, simplemente se extiende lejos
                // --------------------------------------------------------------

                // Si el rayo no golpea nada, extenderlo lejos
                rayoVisual.SetPosition(0, firePoint.position);
                rayoVisual.SetPosition(1, rayo.GetPoint(100));

                // Mostramos el rayo
                rayoVisual.enabled = true;

                // Instanciar la bala y establecer su dirección hacia el punto lejano
                //GameObject bullet = Instantiate(bulletPrefab, firePoint);
                //bullet.transform.SetParent(null);

                // Obtener la dirección hacia el punto final del rayo visual
                Vector3 puntoLejano = rayo.GetPoint(100);
                Vector3 direccion = (puntoLejano - firePoint.transform.position).normalized;
                //bullet.GetComponent<Rigidbody>().velocity = direccion * bulletSpeed;

                // -------------------------------------------------------------------------------------
                // Utilizamos una bala del Object Pool (sustituye a la instanciación si no hay impacto)
                // -------------------------------------------------------------------------------------
                GameObject bullet = ObjectPool.instance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position; // Colocamos el objeto en la posición
                    bullet.SetActive(true); // Activamos el objeto del pool
                    bullet.GetComponent<Rigidbody>().velocity = direccion * bulletSpeed;
                }

            }

        }
        else
        {
            // Si se deja de hacer clic
            if (Input.GetMouseButtonUp(0))
            {

                // Ocultamos el rayo
                rayoVisual.enabled = false;

            }
        }

    }


}
