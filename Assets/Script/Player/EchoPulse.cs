using UnityEngine;
using UnityEngine.InputSystem;

public class EchoPulse : MonoBehaviour
{
    public float maxRadius = 20f;
    public float speed = 10f;

    private float _radius;
    private bool _active;

    public bool IsActive => _active;
    public float CurrentRadius => _radius;


    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _radius = 0f;
            _active = true;
        }

        if (_active)
        {
            _radius += speed * Time.deltaTime;

            Shader.SetGlobalVector("_EchoPosition", transform.position);
            Shader.SetGlobalFloat("_EchoRadius", _radius);

            if (_radius >= maxRadius)
            {
                _active = false;
                Shader.SetGlobalFloat("_EchoRadius", 0f);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (_active)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
