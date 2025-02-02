using JamKit;

namespace Game
{
    public class GameMain : SceneRoot
    {
        protected override void InitScene()
        {
            Camera.backgroundColor = JamKit.Globals.GameSceneCameraBackgroundColor;
        }

        public override string Tick()
        {
            return JamKit.SameScene;
        }

    }
}