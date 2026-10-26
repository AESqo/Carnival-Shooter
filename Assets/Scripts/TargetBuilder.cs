using UnityEngine;

public class TargetBuilder {
    private GameObject _targetObj;
    private Target _targetComponent;
    public TargetBuilder(GameObject prefab, Vector3 spawnPosition) {
         Quaternion spawnRotation = Quaternion.Euler(0f, 0f, -90f);
        _targetObj = Object.Instantiate(prefab, spawnPosition, spawnRotation);
        _targetComponent = _targetObj.GetComponent<Target>() ?? _targetObj.AddComponent<Target>();
    }
    public TargetBuilder SetSpeed(float speed) {
        _targetComponent.Speed = speed;
        return this;
    }
    public TargetBuilder SetPoints(int points) {
        _targetComponent.PointValue = points;
        return this;
    }
    public TargetBuilder SetScale(Vector3 size) {
        _targetComponent.Size = size;
        return this;
    }
    public TargetBuilder SetColor(Color color) {
        _targetComponent.Initialize(_targetComponent.Speed, _targetComponent.PointValue, _targetComponent.Size, color);
        return this;
    }
    public GameObject Build() {
        return _targetObj;
    }
}
