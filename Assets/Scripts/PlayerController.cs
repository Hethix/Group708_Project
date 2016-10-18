using UnityEngine;

public class PlayerController : MonoBehaviour
{
          public Camera Camera;
          private Vector3 m_OriginalCameraPosition;
          public float[] PosData;
          bool moving = false;
          void start()
          {
        m_OriginalCameraPosition = Camera.transform.localPosition;

    }
          int i = 0;
          int count = 0;
    void Update()
    {
        Vector3 newCameraPosition;
        PosData = new float[] {0.1012f,0.1014f,0.1010f,0.1003f,0.0997f,0.0995f,0.0992f,0.0988f,0.0989f,0.0995f,0.1002f,0.1007f,0.1013f,0.1018f,0.1018f,0.1012f,0.1003f,0.0996f,0.0994f,0.0994f,0.0993f,0.0990f
    ,0.0987f,0.0982f,0.0985f,0.0995f,0.1007f,0.1011f,0.1007f,0.0992f};



        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        if (Input.GetButton("Vertical"))
        {
            float move = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
            moving = true;
            transform.Translate(0, 0, move);
        }
        else
        {
            moving = false;
        }



        if (moving == true)

        {
            for (int i = 0; i < PosData.Length - 1;)
            {
                //Debug.Log("Number: " + count + " Float: " + PosData[count]);

                              Camera.transform.position = new Vector3(transform.position.x, transform.position.y + PosData[count] * 10, transform.position.z);
                newCameraPosition = Camera.transform.position;
                newCameraPosition.y = Camera.transform.position.y;
                if (count < 29)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (i >= PosData.Length)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            
            transform.Rotate(0, x, 0);
        }
    }
}