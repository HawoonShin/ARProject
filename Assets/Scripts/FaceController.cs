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
        // ��������
        for(int i = 0; i< 468; i++)
        {
            // ť�� ����
            GameObject cube = Instantiate(cubePrefab);
            cubes.Add(cube);
        }*/
    }

    // OnEnable = ������Ʈ Ȱ���� �� ȣ��Ǵ� �Լ�
    private void OnEnable()
    {
        // ���̽� Ʈ��ŷ�� �ٲ�� ���� �۵�
        faceManager.facesChanged += OnFaceChange;
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceChange;
    }

    private void OnFaceChange(ARFacesChangedEventArgs args)
    {
        // ���� ������ ��? ���� �ϳ��� ����ϹǷ� if������ �ۼ�?
        // = �������� �󱼿� �������(��ġ, ȸ��)�� ���� ��
        if (args.updated.Count > 0)         // ����� �� �ϳ��� �����ϴ� ��
        {
            // AR ���̽��� �����ͼ�
            ARFace face = args.updated[0];

            Vector3 mouthPos01 = face.transform.TransformPoint(face.vertices[11]);
            Vector3 mouthPos02 = face.transform.TransformPoint(face.vertices[15]);
            mouthTracker01.transform.position = mouthPos01;
            mouthTracker02.transform.position = mouthPos02;

            /*
            // �󱼿� �ִ� ��� ����
            for (int i = 0; i < face.vertices.Length; i++) 
            {
                // Ar�� ��� �ڸ� �������� ������ �̷�����ִµ�
                // �θ� �������� �ڽ��� ��ġ�� ������ǥ�� ��ȯ�Ѵ�
                // =  �� ������ ��ġ�� ���� ��ġ�� ��ȯ
                Vector3 vertPos =face.transform.TransformPoint( face.vertices[i]);

                // ������ ť����� ������ ��ġ�� �̵�
                cubes[i].transform.position = vertPos;
            }*/
        }
    }
}
