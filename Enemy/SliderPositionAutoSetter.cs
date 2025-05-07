using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    
    public void Setup(Transform target)
    {
        //slider ui�� �Ѿƴٴ� Ÿ�� ����
        targetTransform = target;
        //RectTransform ������Ʈ ���� ������
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ���� �ı��Ǿ� �Ѿƴٴ� ����� ������� slider ui�� ����
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);

            rectTransform.position = screenPosition + distance;
        }
    }
}
