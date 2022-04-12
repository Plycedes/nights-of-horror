using UnityEngine;

public class M4Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;

    public float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        nextTimeToFire = Time.time + 1f / fireRate; 
    }

    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            ZomDamage target = hit.transform.GetComponent<ZomDamage>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        FindObjectOfType<AudioManager>().Play("GunShot");
    }
}
