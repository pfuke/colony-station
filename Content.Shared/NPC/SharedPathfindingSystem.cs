using System.Numerics;

namespace Content.Shared.NPC;

public abstract class SharedPathfindingSystem : EntitySystem
{
    /// <summary>
    /// This is equivalent to agent radii for navmeshes. In our case it's preferable that things are cleanly
    /// divisible per tile so we'll make sure it works as a discrete number.
    /// </summary>
    public const byte SubStep = 4;

    public const byte ChunkSize = 8;
    public static readonly Vector2 ChunkSizeVec = new(ChunkSize, ChunkSize);

    /// <summary>
    /// We won't do points on edges so we'll offset them slightly.
    /// </summary>
    protected const float StepOffset = 1f / SubStep / 2f;

    private static readonly Vector2 StepOffsetVec = new(StepOffset, StepOffset);

    public Vector2 GetCoordinate(Vector2i chunk, Vector2i index)
    {
        return new Vector2(index.X, index.Y) / SubStep+ (chunk) * ChunkSizeVec + StepOffsetVec;
    }
}
