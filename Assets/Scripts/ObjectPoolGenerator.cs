using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPoolGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private int _objectsAmount;
    [SerializeField] private Transform _parentTransform;

    private readonly List<GameObject> _objects = new List<GameObject>();
    private Camera _camera;

    public void ResetPool()
    {
        foreach (GameObject spawned in _objects)
            spawned.SetActive(false);
    }    

    protected bool TryGetObjectFromPool(out GameObject spawned)
    {
        spawned = _objects.Where(o => o.activeSelf == false).FirstOrDefault();

        if (spawned == null)
            return false;

        return true;
    }

    protected void Initialize()
    {
        _camera = Camera.main;

        for (int i = 0; i < _objectsAmount; i++)
        {
            GameObject spawned = Instantiate(_objectPrefab, _parentTransform);
            spawned.SetActive(false);
            _objects.Add(spawned);
        }
    }


    protected void DisableObjectsAbroadScreen()
    {
        float additionalValue = 10;
        Vector3 leftDisablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3 (-additionalValue, 0, 0);
        Vector3 rightDisablePoint = _camera.ViewportToWorldPoint(new Vector2(1, 0)) + new Vector3(additionalValue, 0, 0);

        var farObjects = _objects.Where(o => o.activeSelf == true).
                                  Where(o => o.transform.position.x < leftDisablePoint.x ||
                                  o.transform.position.x > rightDisablePoint.x);

        foreach (var farObject in farObjects)
            farObject.SetActive(false);
    }
}
