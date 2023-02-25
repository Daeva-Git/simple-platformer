using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 fromPos;

    public Vector3 toPos;
    public float time;
    public float speed;
    
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime * speed;


        if (_timer >= time)
        {
            _timer = 0;

            var tempVector = new Vector3(toPos.x, toPos.y, toPos.z);
            toPos = fromPos;
            fromPos = tempVector;
        } 

        gameObject.transform.position = Vector3.Lerp(fromPos, toPos, _timer / time);
    }
}
