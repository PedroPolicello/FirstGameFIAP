using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform weaponTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spriteTransform;


    private void Awake()
    {
        weaponTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 mousePosition = GetMousePosition();
        Vector3 aimDirection = (mousePosition - weaponTransform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        weaponTransform.eulerAngles = new Vector3(0, 0, aimAngle);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, spriteTransform.position, spriteTransform.rotation);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        return mousePosition;
    }
}
