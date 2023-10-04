using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class Prof : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] float AttackDelay;
    public Queue<Bullet> ProfBullets = new Queue<Bullet>();
    bool isProfPoxIsLeft;


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
            int isLeft = Random.Range(0, 2);
            if(isLeft == 0)
            {
                transform.position = new Vector3(-7.4f, -1, 0);
                isProfPoxIsLeft = true;
            }
            else
            {
                transform.position = new Vector3(7.4f, -1, 0);
                isProfPoxIsLeft = false;
            }

            GameObject bullet = Instantiate(Bullet);
            bullet.GetComponent<Bullet>().Setting((AttackType)Random.Range(0, 3));
            ProfBullets.Enqueue(bullet.GetComponent<Bullet>());
            bullet.transform.position = transform.position;
            if (isProfPoxIsLeft) bullet.GetComponent<Bullet>().ShootRight();
            yield return new WaitForSeconds(AttackDelay);
        }
    }

    public void DestroyBullet()
    {
        Destroy(ProfBullets.Dequeue().gameObject);
    }
}
