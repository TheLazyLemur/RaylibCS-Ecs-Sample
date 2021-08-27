using System;
using System.Numerics;
using Leopotam.Ecs;
using RaylibEcsSample.Components;
using static Raylib_cs.Raylib;

namespace RaylibEcsSample.Systems
{
    internal class TransformSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent>? _transformFilter = null;
        private static readonly Random Rand = new();

        public void Init()
        {
            if (_transformFilter == null) return;
            foreach (var i in _transformFilter)
            {
                ref var transform = ref _transformFilter.Get1(i);
                transform.Velocity = new Vector2(Rand.Next(-1000, 1000), Rand.Next(-1000, 1000));
                transform.Position.X = (float)1920 / 2;
                transform.Position.Y = (float)1080 / 2;
            }
        }

        public void Run()
        {
            if (_transformFilter == null) return;
            foreach (var i in _transformFilter)
            {
                ref var transform = ref _transformFilter.Get1(i);
                transform.Position.X += transform.Velocity.X * GetFrameTime();
                transform.Position.Y += transform.Velocity.Y * GetFrameTime();

                if (transform.Position.Y is <= 0 or >= 1080 - 1)
                {
                    transform.Velocity.Y *= -1;
                }

                if (transform.Position.X is <= 0 or >= 1920 - 1)
                {
                    transform.Velocity.X *= -1;
                }
            }
        }
    }
}