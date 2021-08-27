using System.Numerics;
using Leopotam.Ecs;
using Raylib_cs;
using RaylibEcsSample.Components;
using RaylibEcsSample.Systems;
using static Raylib_cs.Raylib;

EcsWorld? world;
EcsSystems? systems;

LoadRaylibWindow(out var camera);
LoadEcsWorld();
LoadGameEntities(world, systems);
GameLoop();

void LoadRaylibWindow(out Camera2D cam)
{
    InitWindow(1920, 1080, "Sample Project");
    SetTargetFPS(60);
    var camera2D = new Camera2D
    {
        target = new Vector2(),
        offset = new Vector2(),
        rotation = 0.0f,
        zoom = 1.0f
    };
    cam = camera2D;
}

void LoadEcsWorld()
{
    world = new EcsWorld();
    systems = new EcsSystems(world);
}

void LoadGameEntities(EcsWorld? ecsWorld, EcsSystems? ecsSystems)
{
    if (ecsWorld == null) return;
    if (ecsSystems == null) return;

    var fpsEntity = ecsWorld.NewEntity();
    fpsEntity.Get<FpsComponent>();
    
    for (var i = 0; i < 100000; i++)
    {
        var entity = ecsWorld.NewEntity();
        entity.Get<DrawComponent>();
        entity.Get<TransformComponent>();
    }

    ecsSystems.Add(new TransformSystem()).Add(new DrawSystem()).Add(new FpsSystem()).Init();
}

void GameLoop()
{
    while (!WindowShouldClose() && systems is not null)
    {
        ClearBackground(Color.BLACK);
        BeginMode2D(camera);
        systems.Run();
        EndMode2D();
        EndDrawing();
    }
}

