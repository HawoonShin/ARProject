using UnityEngine;

public class MouthState : MonoBehaviour
{
    // 입 열고 닫은 상태 확인
    [SerializeField] bool isMouthOpen;

    // 충돌 확인할 colider
    [SerializeField] Collider Collider;

    private void Awake()
    {
        // 기본상태 = 입 닫은 상태
        isMouthOpen = false;
    }

    // 충돌이 감지되면
    private void OnCollisionEnter(Collision collision)
    {
        // 입 닫힘
        isMouthOpen = false;
        Debug.Log("입닥쳐말포이");
    }

    private void OnCollisionExit(Collision collision)
    {
        // 입 열림
        isMouthOpen = true;
        Debug.Log("입열림");
    }
}
