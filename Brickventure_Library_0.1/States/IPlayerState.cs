﻿namespace Brickventure_Library_0._1.States
{
    public interface IPlayerState
    {
        public void Attack();
        public void Defend();

        public bool WasSuccessfull();

    }
}
