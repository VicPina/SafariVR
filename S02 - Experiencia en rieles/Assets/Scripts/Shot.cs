using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform transOrigin;
    public int points;
    public TextMesh txtPoints;
    public GameObject prefBullet;
    public float shotCooldown = 1.0f;

    protected RaycastHit raycastHit;
    protected Ray ray;
    protected bool cooldownShoot;
    protected GameObject goBullet;

    private void Start()
    {
        ray = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cooldownShoot)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                cooldownShoot = true;
                
                Invoke("TurnOffShoot", 0.1f);
                Invoke("CooldownShoot", shotCooldown);
                
                SimulatedShot();
            }
        }
    }

    protected void SimulatedShot()
    {
        goBullet = Instantiate(prefBullet);

        goBullet.transform.position = transOrigin.position + transform.forward;
        goBullet.transform.forward = transOrigin.forward;

        goBullet.GetComponent<Bullet>().shot = this;
    }

    public void ScoredShot(int points, GameObject hitObject)
    {
        ScorePoints(points);
        Destroy(hitObject);
    }

    protected void ScorePoints(int hitPoints)
    {
        switch (hitPoints)
        {
            case 3:
                points += 8;
                break;
            case 2:
                points += 3;
                break;
            case 1:
                points += 1;
                break;
        }

        txtPoints.text = "" + points;
    }

    protected void CooldownShoot()
    {
        cooldownShoot = false;
    }
}
