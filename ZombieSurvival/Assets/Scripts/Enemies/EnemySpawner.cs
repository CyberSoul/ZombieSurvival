using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float m_periodMin;
    public float m_periodMax;
    public GameObject m_enemy;
    float m_nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        m_nextSpawnTime = Time.time + Random.Range(m_periodMin, m_periodMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_nextSpawnTime <= Time.time )
        {
            m_nextSpawnTime = Time.time + Random.Range(m_periodMin, m_periodMax);
            Instantiate(m_enemy, transform.position, transform.rotation);
        }
    }
}
