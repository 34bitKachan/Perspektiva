using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObjKeyUpDown : MonoBehaviour
{
    public Camera mainCamera; // ������ �� �������� ������
    public float scalingSpeed = 1f; // �������� ��������� �������
    public float distanceFromCamera = 5f; // ����������� ���������� �� ������

    private Vector3 initialScale; // �������� ������ �������

    void Start()
    {
        initialScale = transform.localScale; // ��������� �������� ������ �������
        UpdatePosition(); // ������������� ��������� �������
    }

    void Update()
    {
        // �������� ������� ������ ��� ��������� �������
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ScaleObject(1); // ���������� �������
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ScaleObject(-1); // ���������� �������
        }

        // ������������� ������� �������, ����� �� ��������� �� ����� ����������
        UpdatePosition();
    }

    private void ScaleObject(int direction)
    {
        // ������������ ����� ������ �������
        float newScale = transform.localScale.x + direction * scalingSpeed * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // ������������� ������� ������� �� ������ ��������� �������
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        // ������������ ����� ������� ������� �� ��������� ���������� � ��������� �������
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 direction = (transform.position - cameraPosition).normalized;
        transform.position = cameraPosition + direction * distanceFromCamera * transform.localScale.x / initialScale.x;
    }
}
