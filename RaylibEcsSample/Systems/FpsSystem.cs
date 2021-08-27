using System.Numerics;
using Leopotam.Ecs;
using RaylibEcsSample.Components;
using static Raylib_cs.Raylib;

namespace RaylibEcsSample.Systems
{
    public class FpsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<FpsComponent>? _fpsFilter = null;
        private FpsComponent _current;

        public void Init()
        {
            if (_fpsFilter != null)
                _current = _fpsFilter.Get1(1);

            _current.Position = new Vector2((float)1920/2, 10);
        }

        public void Run()
        {
            DrawFPS((int)_current.Position.X, (int)_current.Position.Y);
        }
    }
}