using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    public Transform Potal;

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbady(����)�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ������ �ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }
    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Cheese")
        {
            // �� ��ġ�� ��Ż ������Ʈ ��ġ�� �̵�
            transform.position = Potal.position;
        }

       if (other.tag == "Goal")
        {
            gameObject.SetActive(false);
            // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
            GameManager gameManager = FindObjectOfType<GameManager>();
            // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
            gameManager.WinGame();
        }
    }

}
