using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private float verticalInput;
    private float horizontalInput;
    public GameObject bulletPrefab;
    public GameObject focusPoint;
    private float shootCountdown;
    public float shootCountdownVal;
    public GameObject table;
    public int tableCooldown;
    public int hitmenLeft;
    // Start is called before the first frame update
    void Start()
    {
        tableCooldown = 0;
        hitmenLeft = 155;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        if (Input.GetMouseButton(0) && shootCountdown <= 0)
        {
            SpawnBullet();
            shootCountdown = shootCountdownVal;
        }
        if (Input.GetKeyDown(KeyCode.Space) && tableCooldown >= 5)
        {
            SpawnTable();
        }
        shootCountdown -= Time.deltaTime;
    }
    void PlayerMovement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 axisInput = new Vector2(horizontalInput, verticalInput);

        transform.Translate(new Vector2(1,1) * axisInput * moveSpeed * Time.deltaTime, Space.World);
    }
    void PlayerRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
    void SpawnBullet()
    {
        Instantiate(bulletPrefab,focusPoint.transform);
        focusPoint.transform.DetachChildren();
    }
    void SpawnTable()
    {
        Instantiate(table,focusPoint.transform);
        focusPoint.transform.DetachChildren();
        tableCooldown -= 5;
    }
}
