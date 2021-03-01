using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Shot shot;
    public float bulletSpeed = 25.0f;

    private float cronometer;
    protected RaycastHit raycastHit;
    protected Ray ray;

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * bulletSpeed;
        cronometer += Time.deltaTime;

        ScanShot();

        if (cronometer > 5.0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "P":
                shot.ScoredShot(3, other.gameObject);
                Destroy(gameObject);
                break;
            case "T":
                shot.ScoredShot(2, other.gameObject);
                Destroy(gameObject);
                break;
            case "S":
                shot.ScoredShot(1, other.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    protected void ScanShot()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * Time.fixedDeltaTime * bulletSpeed, Color.red, Time.deltaTime);

        int layerMask = (1 << 8) | (1 << 9) | (1 << 10);

        if (Physics.Raycast(ray, out raycastHit, Time.fixedDeltaTime * bulletSpeed, layerMask))
        {
            switch (raycastHit.collider.gameObject.layer)
            {
                case 8:
                    shot.ScoredShot(3, raycastHit.collider.gameObject);
                    break;
                case 9:
                    shot.ScoredShot(2, raycastHit.collider.gameObject);
                    break;
                case 10:
                    shot.ScoredShot(1, raycastHit.collider.gameObject);
                    break;
            }
        }
    }
}
