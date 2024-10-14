using System.Collections;
using UnityEngine;

public class DoughnutState : MonoBehaviour
{
    // 마우스 트래커 가져오기
    [SerializeField] GameObject mouthTracker;

    // 입여댣 체크
    private bool mouthCheck;

   

    private void Awake()
    {
        // 생성된 마우스 트래커 하나 찾기
        mouthTracker = GameObject.FindWithTag("Tracker");

        StartCoroutine(DestroyCorooutine());


        // 확인용
        Debug.Log($"도넛 위치 :{gameObject.transform.position}");

    }

    private void Update()
    {
        // 찾은 오브젝트의 스크립트 가져오기
        mouthCheck = mouthTracker.GetComponent<MouthState>().isMouthOpen;

    }

    // 일정 시간 후 자동 삭제
    IEnumerator DestroyCorooutine()
    {
        // 5초 뒤 자동 삭제
        yield return new WaitForSeconds(5f);
        Destroy (gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌 감지");
        Destroy(gameObject);
    }
}
