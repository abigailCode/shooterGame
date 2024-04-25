using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] Camera _playerCamera;
    [SerializeField] Transform _firePoint;
    [SerializeField] int _bulletSpeed = 20;
    [SerializeField] LineRenderer _visualRay;

    void Start() { _visualRay.enabled = false; }

    void Update() {
        if (Input.GetMouseButtonUp(0)) _visualRay.enabled = false;
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = _playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            Vector3 puntoImpacto = hit.point;

            _visualRay.enabled = true;
            _visualRay.SetPosition(0, _firePoint.position);
            _visualRay.SetPosition(1, puntoImpacto);

            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if (bullet != null) {
                bullet.transform.position = _firePoint.position;
                bullet.SetActive(true);
                bullet.GetComponent<PlaySFX>().PlaySFXClip();
                Vector3 direccionImpacto = (puntoImpacto - _firePoint.transform.position).normalized;
                bullet.GetComponent<Rigidbody>().velocity = direccionImpacto * _bulletSpeed;
            }
        }else {
            _visualRay.SetPosition(0, _firePoint.position);
            _visualRay.SetPosition(1, ray.GetPoint(100));

            _visualRay.enabled = true;

            Vector3 puntoLejano = ray.GetPoint(100);
            Vector3 direccion = (puntoLejano - _firePoint.transform.position).normalized;
            
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if (bullet != null) {
                bullet.transform.position = _firePoint.position;
                bullet.SetActive(true);
                bullet.GetComponent<PlaySFX>().PlaySFXClip();
                bullet.GetComponent<Rigidbody>().velocity = direccion * _bulletSpeed;
            }
        }
    }
}
