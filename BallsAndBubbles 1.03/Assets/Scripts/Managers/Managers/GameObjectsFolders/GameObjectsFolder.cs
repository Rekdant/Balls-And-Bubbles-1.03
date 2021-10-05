using UnityEngine;

public enum Folder
{
    FBX,
    VFX
}

public class GameObjectsFolder : MonoBehaviour
{
    [SerializeField] private Transform _objectsFolder;
    [SerializeField] private Transform _effectsFolder;

    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<GameObjectsFolder>();
    }

    public Transform Get(Folder folder)
    {
        switch (folder)
        {
            case Folder.FBX:
                    return _objectsFolder;
            case Folder.VFX:
                    return _effectsFolder;
            default:
                    return null;
        }
    }
}
