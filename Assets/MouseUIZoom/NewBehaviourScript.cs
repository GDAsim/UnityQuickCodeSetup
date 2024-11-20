using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] RectTransform area;
    [SerializeField] RectTransform scrollarea;

    void Update()
    {
        if(Mathf.Abs(Input.mouseScrollDelta.y) > 0)
        {
            var scale = area.localScale.x;

            //mousePosition contains position of mouse inside scaled area in percentages
            var mousePosition = (Vector2)(Input.mousePosition - area.position) - area.rect.position * scale;
            mousePosition.x /= area.rect.width * scale;
            mousePosition.y /= area.rect.height * scale;

            var contentSize = scrollarea.content.rect;
            var shiftX = -scaleDelta * contentSize.width * (mousePosition.x - 0.5f);
            var shiftY = -scaleDelta * contentSize.height * (mousePosition.y - 0.5f);
            var currPos = scrollarea.content.localPosition;
            scrollarea.content.localPosition = new Vector3(currPos.x + shiftX, currPos.y + shiftY, currPos.z);
        }
    }


    void Zoom()
    {
        //https://stackoverflow.com/questions/33433872/zoom-to-mouse-position-like-3ds-max-in-unity3d?rq=3
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            RaycastHit hit;
            Ray ray = this.transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Vector3 desiredPosition;

            if (Physics.Raycast(ray, out hit))
            {
                desiredPosition = hit.point;
            }
            else
            {
                desiredPosition = transform.position;
            }
            float distance = Vector3.Distance(desiredPosition, transform.position);
            Vector3 direction = Vector3.Normalize(desiredPosition - transform.position) * (distance * Input.GetAxis("Mouse ScrollWheel"));

            transform.position += direction;
        }
    }
}
