using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace JamKit
{
    public interface IScene
    {
        void Init(JamKit jamKit, Camera camera);
        string Tick();
        void Exit();
    }

    public abstract class SceneRoot : MonoBehaviour, IScene
    {
        [SerializeField] private Image _coverImage;

        protected JamKit JamKit { get; private set; }
        protected Camera Camera { get; private set; }

        public void Init(JamKit jamKit, Camera camera)
        {
            JamKit = jamKit;
            Camera = camera;

            JamKit.Tween(new TweenImageColor(_coverImage, JamKit.Globals.SceneTransitionParams.Color, JamKit.Globals.SceneTransitionParams.Duration));

            InitScene();
        }

        protected abstract void InitScene();

        public abstract string Tick();

        public virtual void Exit()
        {
            JamKit.Tween(new TweenImageColor(_coverImage, Color.clear, JamKit.Globals.SceneTransitionParams.Duration));
        }


    }
}