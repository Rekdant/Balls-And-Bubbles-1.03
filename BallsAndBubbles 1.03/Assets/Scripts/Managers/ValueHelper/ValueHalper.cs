public static class ValueHalper
{
    #region Ring

    public const float RingMovementPointPositionXaxisMin = -5;
    public const float RingMovementPointPositionXaxisMax = 5;
    public const float RingMovementPointPositionYaxisMin = 0;
    public const float RingMovementPointPositionYaxisMax = 5;

    #endregion

    #region PlaySpace

    public const float PlaySpacePositionXaxisMin = -7f;
    public const float PlaySpacePositionXaxisMax = 7f;
    public const float PlaySpacePositionYaxisMin = -4f;
    public const float PlaySpacePositionYaxisMax = 14f;

    #endregion

    #region PlayerPrefsKey

    public const string KeyIntensitySphereSpawnInTrainingMod = "IntensitySphereSpawnInTrainingMod";
    public const string KeyTrainingRecord = "TrainingRecord";
    public const string KeyMusicVolume = "MusicVolume";
    public const string KeySoundVolume = "SoundVolume";
    public const string KeyCameraSize = "CameraDistance";

    #endregion

    #region DefaultValue

    public const int DefaultSoundVolume = 10;
    public const int DefaultMusicVolume = 5;
    public const float DefaultIntensitySphereSpawnInTrainingMod = 3;
    public const float DefaultCameraSize = 7;

    #endregion
}
