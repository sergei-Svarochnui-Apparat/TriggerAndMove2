using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayr : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ������������
    public float jumpHeight = 2f; // ������ ������
    public float gravity = -9.8f; // ���� ����������
    private float ySpeed = 0f; // ������������ ��������

    private CharacterController controller;
    private Vector3 velocity;

    private bool isGrounded; // ��������, ��������� �� �������� �� �����

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ��������, ��������� �� �������� �� �����
        isGrounded = controller.isGrounded;

        // ��������� ��������������� ������������
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // ��������� ������������ �������� (������ � ����������)
        if (isGrounded && ySpeed < 0)
        {
            ySpeed = -2f; // ��������� �����������, ����� �������� �� ������� � �������
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity); // ������� ��� ������
        }

        ySpeed += gravity * Time.deltaTime; // ��������� ����������

        velocity = new Vector3(move.x, ySpeed, move.z);

        // ������� ���������
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
