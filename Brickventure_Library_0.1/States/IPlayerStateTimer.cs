﻿namespace Brickventure_Library_0._1.States
{
    public interface IPlayerStateTimer
    {
        void Start();
        void Stop();
        void IncreaseDifficulty(int amount);
        void Reset();
    }
}
