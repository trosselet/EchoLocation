using UnityEngine;

public class EchoVisual : MonoBehaviour
{
    public EchoPulse pulse;

    void Update()
    {
        if (pulse.IsActive)
        {
            float r = pulse.CurrentRadius;
            transform.localScale = new Vector3(r * 2, r * 2, r * 2);
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}