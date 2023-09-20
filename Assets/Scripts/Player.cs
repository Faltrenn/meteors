using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    private InputActions inputActions;

    private Vector2 moveAxis, lookAxis;

    [SerializeField] private GameObject projetcile;
    [SerializeField] private GameObject cannon;

    void Start()
    {
        inputActions = new InputActions();
        inputActions.Movement.Enable();

        inputActions.Movement.Shoot.performed += Shoot; 
    }

    void Update()
    {
        moveAxis = inputActions.Movement.Move.ReadValue<Vector2>();
        lookAxis = inputActions.Movement.Look.ReadValue<Vector2>();

        transform.position += (Vector3)moveAxis * speed * Time.deltaTime;


        if(lookAxis != Vector2.zero) {
            transform.up = lookAxis;
        } else if(moveAxis != Vector2.zero) {
            transform.up = moveAxis;
        }

    }

    void Shoot(InputAction.CallbackContext ctx) {
        GameObject p = Instantiate(projetcile, cannon.transform.position, Quaternion.identity);
        p.transform.up = transform.up;
    }
}
