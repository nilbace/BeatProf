using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Prof : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] float AttackDelay;
    public Queue<Bullet> ProfBullets = new Queue<Bullet>();


    public static Prof instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(ShootBullet());
    }

    IEnumerator ShootBullet()
    {
        while(true)
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.GetComponent<Bullet>().Setting((AttackType)Random.Range(0, 3));
            ProfBullets.Enqueue(bullet.GetComponent<Bullet>());
            yield return new WaitForSeconds(AttackDelay);
        }
    }

    public void DestroyBullet()
    {
        Destroy(ProfBullets.Dequeue().gameObject);
    }
}
