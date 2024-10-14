using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // 일정 시간 간격으로
    // 발사 간격 타이밍
    [SerializeField] float shootDelay;

    // 발사할 오브젝트
    [SerializeField] GameObject sweetPrefab;
    // 발사 스피드
    [SerializeField] float shootSpeed;

    // 발사 지점
    private Vector3 shootPosition;

    // 코루틴 실행 확인
    private bool isCoroutine;

    // 오프셋
    [SerializeField] Vector3 shootPosOffest;

    private void Awake()
    {
        // 시작시 코루틴 초기화
        // false = 코루틴 종료 상태
        isCoroutine = false;

    }

    private void Update()
    {
        // 코루틴 실행
        if (isCoroutine == false)
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    // 오브젝트를 발사
    private void Shoot()
    {
        // 화면 전환 시 따라갈수 있도록 shoot함수 안쪽으로 이동
        shootPosition = Camera.main.transform.position + shootPosOffest;

        Debug.Log("발사");
        GameObject ball = Instantiate(sweetPrefab, Return_RandomPosition(), Camera.main.transform.rotation);
        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.velocity = shootSpeed * Vector3.forward;

        // 코루틴 실행용
        isCoroutine = true;
    }

    // 발사 코루틴
    IEnumerator ShootCoroutine()
    {
        Debug.Log("코루틴 시작");

        Shoot();

        // 발사 딜레이만큼
        yield return new WaitForSeconds(shootDelay);

        // 코루틴 종료용?
        isCoroutine = false;
    }

    // 랜덤 위치 생성
    // 랜덤 위치 생성
    Vector3 Return_RandomPosition()
    {
        // X축만 랜덤하게 변경, Y축과 Z축은 그대로 유지
        // 핸드폰 기준으로 설정된 값
        // 테블릿에 적용할 경우 더 넓은 값 사용 가능
        float randomX = Random.Range(shootPosition.x - 0.2f, shootPosition.x + 0.2f);

        // 카메라 위에서 Y축 및 Z축 유지, X축만 랜덤
        Vector3 spawnPosition = new Vector3(randomX, shootPosition.y, shootPosition.z);

        // 위치 확인용
       // Debug.Log($"도넛 생성 위치 : {spawnPosition}");

        return spawnPosition;
    }
}
