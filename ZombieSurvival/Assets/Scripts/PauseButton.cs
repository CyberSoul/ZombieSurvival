using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject m_paussedMenu;
    bool m_isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausePressed()
    {
        m_isPaused = !m_isPaused;
        m_paussedMenu.SetActive(m_isPaused);
        Time.timeScale = m_isPaused ? 0 : 1;
    }
}
