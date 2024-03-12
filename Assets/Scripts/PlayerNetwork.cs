using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 moveDir;

    private void Update() {

        if (!IsOwner) return;

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        float moveSpeed = 5f;

        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    private void FixedUpdate() {
        if (moveDir != Vector3.zero)
            rb.MoveRotation(Quaternion.Euler(0, Mathf.Atan2(_horizontalInput, _verticalInput) * Mathf.Rad2Deg, 0));
    }
}
