using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private int linesCount = 3;
    [SerializeField] private float horizontalStep = 3f;
    private float bound = 1;

    private int line = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && line > -bound)
        {
            // line = line - 1
            line -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && line < bound)
        {
            //line = line + 1
            line += 1;
        }

        transform.position = new Vector3(line * horizontalStep, transform.position.y, transform.position.z);
    }
}
