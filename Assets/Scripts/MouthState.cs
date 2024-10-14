using UnityEngine;

public class MouthState : MonoBehaviour
{
    // 입 열고 닫은 상태 확인
    [SerializeField] public bool isMouthOpen;

    // 충돌 확인할 colider
    // [SerializeField] Collider Collider;

    // 발사할 라인 사이즈
    public float lineSize = 5;

    private void Awake()
    {
        // 기본상태 = 입 닫은 상태
        isMouthOpen = false;
    }

    private void Update()
    {
        // Debug.Log($"입 열림 확인 :{isMouthOpen}");

        // 위에서 아래로 내려올 경우 어째서인지 레이캐스트가 반응하지 않음
        // 앞으로 쏳아지는 경우에는 레이캐스트가 발동함
        // 오브젝트 위치의 문제가 있는것으로 추측
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, lineSize))
        {
            // 닿은 물체의 이름을 출력
            //  Debug.Log(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "sweet")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    // 충돌이 감지되면
    private void OnCollisionEnter(Collision collision)
    {
        // 입 닫힘
        if (collision.gameObject.tag == "Tracker")
        {
            isMouthOpen = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isMouthOpen = true;
    }
}
