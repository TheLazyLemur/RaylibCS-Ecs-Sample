using System.Numerics;
using Leopotam.Ecs;
using Raylib_cs;
using RaylibEcsSample.Components;
using RaylibEcsSample.Systems;
using static Raylib_cs.Raylib;

namespace RaylibEcsSample
{
    internal static class Program
    {
        private static void Main()
        {
            InitWindow(1920, 1080, "Sample Project");
            SetTargetFPS(60); 
            var camera = new Camera2D
            {
                target = new Vector2(),
                offset = new Vector2(),
                rotation = 0.0f,
                zoom = 1.0f
            };
            
            var world = new EcsWorld();

            for (var i = 0; i < 100000; i++)
            {
                var entity = world.NewEntity();
                entity.Get<DrawComponent>();
                entity.Get<TransformComponent>();
            }

            var systems = new EcsSystems(world);
            systems.Add(new TransformSystem()).Add(new DrawSystem()).Init();

            
            while (!WindowShouldClose())
            {
                ClearBackground(Color.BLACK);
                BeginMode2D(camera);
                DrawFPS(1920/2,10); 
                
                systems.Run();
                
                EndMode2D();
                EndDrawing();
            }
        }

    }
}