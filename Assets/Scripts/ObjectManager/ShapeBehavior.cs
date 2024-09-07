using UnityEngine;
using static ShapeBehavior;

public abstract class ShapeBehavior
#if UNITY_EDITOR
    : ScriptableObject
#endif
{
    public enum ShapeBehaviorType
    {
        Movement,
        Rotation,
        Oscillation,
        Satellite,
        Growing,
        Dying
    }

    public abstract bool GameUpdate(Shape shape);

    public abstract void Save(GameDataWriter writer);

    public abstract void Load(GameDataReader reader);

    public abstract ShapeBehaviorType BehaviorType { get; }

    public abstract void Recycle();
#if UNITY_EDITOR
    public bool IsReclaimed { get; set; }

    void OnEnable()
    {
        if (IsReclaimed)
        {
            Recycle();
        }
    }
#endif

    public virtual void ResolveShapeInstances() { }
}

public static class ShapeBehaviorTypeMethods
{
    public static ShapeBehavior GetInstance(this ShapeBehaviorType type)
    {
        switch (type)
        {
            case ShapeBehaviorType.Movement:
                return ShapeBehaviorPool<MovementShapeBehavior>.Get();
            case ShapeBehaviorType.Rotation:
                return ShapeBehaviorPool<RotationShapeBehavior>.Get();
            case ShapeBehaviorType.Oscillation:
                return ShapeBehaviorPool<OscillationShapeBehavior>.Get();
            case ShapeBehaviorType.Satellite:
                return ShapeBehaviorPool<SatelliteShapeBehavior>.Get();
            case ShapeBehaviorType.Growing:
                return ShapeBehaviorPool<GrowingShapeBehavior>.Get();
        }
        UnityEngine.Debug.Log("Forgot to support " + type);
        return null;
    }
}