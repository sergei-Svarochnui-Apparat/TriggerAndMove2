using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayr : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения
    public float jumpHeight = 2f; // Высота прыжка
    public float gravity = -9.8f; // Сила гравитации
    private float ySpeed = 0f; // Вертикальная скорость

    private CharacterController controller;
    private Vector3 velocity;

    private bool isGrounded; // Проверка, находится ли персонаж на земле

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Проверка, находится ли персонаж на земле
        isGrounded = controller.isGrounded;

        // Обработка горизонтального передвижения
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Обработка вертикальной скорости (прыжок и гравитация)
        if (isGrounded && ySpeed < 0)
        {
            ySpeed = -2f; // Небольшой коэффициент, чтобы персонаж не зависал в воздухе
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity); // Формула для прыжка
        }

        ySpeed += gravity * Time.deltaTime; // Применяем гравитацию

        velocity = new Vector3(move.x, ySpeed, move.z);

        // Двигаем персонажа
        controller.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
