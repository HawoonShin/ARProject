using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceController : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;
    [SerializeField] GameObject mouthPrefab;

    private GameObject upperLip;
   private GameObject underLip;



    private void Awake()
    {
        // 열고닫음 확인용 윗입술 지점
        upperLip = Instantiate(mouthPrefab);
        underLip = Instantiate(mouthPrefab);

    }

    // OnEnable = 오브젝트 활성될 때 호출되는 함수
    private void OnEnable()
    {
        // 페이스 트래킹이 바뀌는 동안 작동
        faceManager.facesChanged += OnFaceChange;
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChange;
    }

    private void OnFaceChange(ARFacesChangedEventArgs args)
    {
        // 얼굴이 변했을 때? 얼굴을 하나만 사용하므로 if문으로 작성?
        // = 추적중인 얼굴에 변경사항(위치, 회전)이 있을 때
        if (args.updated.Count > 0)         // 현재는 얼굴 하나만 적용하는 중
        {
            // AR 페이스를 가져와서
            ARFace face = args.updated[0];

            // 윗입술
            Vector3 mouthPos01 = face.transform.TransformPoint(face.vertices[11]);
            upperLip.transform.position = mouthPos01;

            // 아랫입술
            Vector3 mouthPos02 = face.transform.TransformPoint(face.vertices[15]);
            underLip.transform.position = mouthPos02;
            

            // Debug.Log($"입 위치 : {mouthPos01}");

        }
    }
}
