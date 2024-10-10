using UnityEngine;

public class MouthState : MonoBehaviour
{
    // �� ���� ���� ���� Ȯ��
    [SerializeField] bool isMouthOpen;

    // �浹 Ȯ���� colider
    [SerializeField] Collider Collider;

    private void Awake()
    {
        // �⺻���� = �� ���� ����
        isMouthOpen = false;
    }

    // �浹�� �����Ǹ�
    private void OnCollisionEnter(Collision collision)
    {
        // �� ����
        isMouthOpen = false;
        Debug.Log("�Դ��ĸ�����");
    }

    private void OnCollisionExit(Collision collision)
    {
        // �� ����
        isMouthOpen = true;
        Debug.Log("�Կ���");
    }
}
