using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class PlayerShotController : MonoBehaviour
{
    //Neede for know where we start fire.
    public Transform m_gunBarrel;
    public PlayerStats m_initStats;
    public Shot m_shot;
    public Transform m_playerTransform;
    //public NavMeshAgent m_navMeshAgent; //Needed for rotation

    private float m_shotDelay;
    private float m_nextShotTime;
    //private float m_attackRange;

    // Start is called before the first frame update
    void Start()
    {
        //m_attackRange = m_initStats.
        m_shotDelay = m_initStats.AttackDelay;
        m_nextShotTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_nextShotTime <= Time.time)
        {
            Zombie target = FindClosetEnemy();
            if (target)
            {
                m_playerTransform.rotation = Quaternion.LookRotation(new Vector3(target.transform.position.x, 0, target.transform.position.z));
                ShotTarget(target);
            }
        }
    }

    Zombie FindClosetEnemy()
    {
        Zombie target = null;
        Zombie[] enemies = FindObjectsOfType<Zombie>();
        if (enemies.Length > 0)
        {
            var currentPosition = transform.position;
            float closetDist = float.MaxValue;//Vector3.Distance(target.transform.position, currentPosition);
            foreach (var enemy in enemies)
            //for (int i = 1; i < enemies.Length; ++i)
            {
                //var enemy = enemies[i];
                if (!enemy.IsDead)
                {
                    float dist = Vector3.Distance(enemy.transform.position, currentPosition);
                    if (closetDist > dist)
                    {
                        closetDist = dist;
                        target = enemy;
                    }
                }
            }
            /*if (target != null)
            {
                ShotTarget(target);
            }*/
        }
        return target;
    }

    void ShotTarget(Zombie a_target)
    {
        /*var from = gunBarrel.position;
        var target = a_target.transform.position;
        shot.Show(from, target);
        a_target.Kill();*/
        var from = m_gunBarrel.position;
        var target = a_target.transform.position;


        //Check for some objects between target and player.
        RaycastHit hit;
        if (Physics.Raycast(from, target - from, out hit, 100))
        {
            target = new Vector3(hit.point.x, from.y, hit.point.z);
            if (hit.transform != null)
            {
                var zombie = hit.transform.GetComponent<Zombie>();
                if (zombie != null)
                    zombie.Kill();
            }
        }
        else
        {
            var direction = (target - from).normalized;
            target = from + direction * 100;
        }
        m_shot.Show(from, target);
        m_nextShotTime = Time.time + m_shotDelay;
    }
}
