using UnityEngine;
using UnityEngine.UI;

namespace Game.Events
{
    #region GameStateEvents

    public class GameWinEvent { public int StarsAmaunt; }
    public class GameLoseEvent { }
    public class GameEndWithCurrentResultEvent { }
    public class GameChangePauseStateEvent { }

    #endregion

    #region TransferFilteredDataEvent

    public class TransferFilteredTimeEvent { public int Value; }
    public class TransferFilteredSphereAmauntEvent { public int Value; }
    public class TransferFilteredPlayerScoreEvent
    {
        public int TotalScore;
        public int GreenSphereScore;
        public int RedSphereScore;
        public int BlueSphereScore;
        public int YellowSphereScore;
        public int WhiteSphereScore;
        public int BlackSphereScore;
        public int MultycoloredSheres;
        public int FishScore;
    }
    public class TransferFilteredFishHunterScoreEvent { public int TotalScore; }

    #endregion

    #region CameraEvent

    public class CameraChangeSizeEvent { public float Value; }
    public class CameraShakeEvent { }

    #endregion

    #region SphereEvent

    public class SphereSpawnEvent { }
    public class SphereDestroyEvent { }
    public class SphereAddGreenSphereScoreEvent { }
    public class SphereAddRedSphereScoreEvent { }
    public class SphereAddBlueSphereScoreEvent { }
    public class SphereAddYellowSphereScoreEvent { }
    public class SphereAddWhiteSphereScoreEvent { }
    public class SphereAddBlackSphereScoreEvent { }
    public class SphereAddMulticoloredSphereScoreEvent { }

    #endregion

    #region TimerEvent

    public class TimerAddVolueEvent { public float Value; }

    #endregion

    #region FishEvent

    public class FishDestroyEvent { };
    public class FishHunterDestroySphereEvent { }

    #endregion

    #region TrainingEvent

    public class TrainingSetSphereToSpawnEvent { public Sphere Sphere; }
    public class TrainingSetValueToIntensitySphereSpawn { public float Value; }

    #endregion

    #region BorderEvent

    public class BorderColorChangeEvent { public Color Color; }

    #endregion
}

