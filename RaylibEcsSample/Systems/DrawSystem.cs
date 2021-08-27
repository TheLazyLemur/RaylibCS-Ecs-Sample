using System;
using Leopotam.Ecs;
using Raylib_cs;
using RaylibEcsSample.Components;
using static Raylib_cs.Raylib;


namespace RaylibEcsSample.Systems
{
    internal class DrawSystem : IEcsInitSystem, IEcsRunSystem 
    {
        private readonly EcsFilter<TransformComponent, DrawComponent>? _transformFilter = null;

        private static Random _rand = new Random();

        public void Init()
        {
            if (_transformFilter != null)
                foreach (var i in _transformFilter)
                {
                    ref var transform = ref _transformFilter.Get1(i);
                    ref var rectangle = ref _transformFilter.Get2(i);
                    rectangle.Rectangle.height = 1;
                    rectangle.Rectangle.width = 1;
                    transform.Position.X = (float)1920 / 2;
                    transform.Position.Y = (float)1080 / 2;
                }
        }

        public void Run()
        {
            if (_transformFilter != null)
                foreach (var i in _transformFilter)
                {
                    ref var transform = ref _transformFilter.Get1(i);
                    ref var rectangle = ref _transformFilter.Get2(i);

                    rectangle.Rectangle.x = transform.Position.X;
                    rectangle.Rectangle.y = transform.Position.Y;

                    DrawRectangleRec(rectangle.Rectangle, Color.SKYBLUE);
                }
        }
    }
}