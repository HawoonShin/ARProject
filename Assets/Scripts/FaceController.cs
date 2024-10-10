using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceController : MonoBehaviour
{
    [SerializeField] ARFaceManager faceManager;

   // [SerializeField] List<GameObject> cubes = new List<GameObject>(468);
    [SerializeField] GameObject mouthPrefab;

    private GameObject mouthTracker01;
    private GameObject mouthTracker02;

    private void Awake()
    {
        mouthTracker01 = Instantiate(mouthPrefab);
        mouthTracker02 = Instantiate(mouthPrefab);
        /*
        // 정점마다
        for(int i = 0; i< 468; i++)
        {
            // 큐브 생성
            GameObject cube = Instantiate(cubePrefab);
            cubes.Add(cube);
        }*/
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

            Vector3 mouthPos01 = face.transform.TransformPoint(face.vertices[11]);
            Vector3 mouthPos02 = face.transform.TransformPoint(face.vertices[15]);
            mouthTracker01.transform.position = mouthPos01;
            mouthTracker02.transform.position = mouthPos02;

            /*
            // 얼굴에 있는 모든 점을
            for (int i = 0; i < face.vertices.Length; i++) 
            {
                // Ar의 경우 코를 기준으로 점들이 이루어져있는데
                // 부모를 기준으로 자식의 위치를 월드좌표로 변환한다
                // =  얼굴 기준의 위치를 월드 위치로 변환
                Vector3 vertPos =face.transform.TransformPoint( face.vertices[i]);

                // 생성한 큐브들을 기준의 위치로 이동
                cubes[i].transform.position = vertPos;
            }*/
        }
    }
}
