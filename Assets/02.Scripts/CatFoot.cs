using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoot : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    private Rigidbody bulletRigidbody;
    // ź�� �̵� �ӷ�
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ �ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    // Ʈ���Ű� '�浹�ϴ� ����' �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player ��ũ�� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            MouseController mouseController = other.GetComponent<MouseController>();

            // �������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if (mouseController != null)
            {
                // ���� PlayerController ������Ʈ�� Die()�޼��� ����
                mouseController.Die();
            }
        }
    }
}
