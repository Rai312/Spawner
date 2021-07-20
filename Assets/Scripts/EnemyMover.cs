using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;

    private void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}
