using UnityEngine;

public class LookAtFoward : MonoBehaviour
{
    [SerializeField] private float _rotationDegreesDelta = 360f;

    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    private Vector3 currentRotation;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    public void LookForwardSmoothly()
    {
        // PROBABLY I HAVE TO TEST THIS CONDITION AND CHECK IF IT'S BETTER WITHOUT IT
        //if (_rigidbody.velocity != Vector3.zero)
        //{
        //    Quaternion rotationDirection = Quaternion.LookRotation(_rigidbody.velocity.normalized);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, _rotationDegreesDelta * Time.deltaTime);
        //}
        if (_rigidbody.velocity.normalized == Vector3.zero) return;

        Quaternion rotationDirection = Quaternion.LookRotation(_rigidbody.velocity.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, _rotationDegreesDelta * Time.deltaTime);
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Mantener el eje X en 0
        currentRotation.x = 0f;
        currentRotation.z = 0f;

        // Aplicar la nueva rotación al objeto
        transform.rotation = Quaternion.Euler(currentRotation);
    }

    public void LookForwardImmediately()
    {
        if (_rigidbody.velocity.normalized == Vector3.zero) return;

        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity.normalized);
    }

    public void LookForward(Vector3 forwardDirection)
    {
        transform.rotation = Quaternion.LookRotation(forwardDirection);
    }

}
