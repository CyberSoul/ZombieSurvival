using UnityEngine;

public class Shot : MonoBehaviour
{
    public LineRenderer m_lineRenderer;
    bool m_isVisible;

    void FixedUpdate()
    {
        if (m_isVisible)
            m_isVisible = false;
        else
            gameObject.SetActive(false);
    }
    public void Show(Vector3 from, Vector3 to)
    {
        m_lineRenderer.SetPositions(new Vector3[] { from, to });
        m_isVisible = true;
        gameObject.SetActive(true);
    }
}
