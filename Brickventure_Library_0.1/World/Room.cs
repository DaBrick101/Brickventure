﻿using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using System.Collections.Generic;

namespace Brickventure_Library_0._1.Environment
{
    public class Room : IRoom
    {
        private RoomType _roomType;
        private List<IPartecipant> _participants;
        private bool wasVisitedByPlayer;
        private int _isActive;
        private int _z;
        private int _y;
        private int _x;

        public Room(RoomType roomType, int z, int y, int x)
        {
            wasVisitedByPlayer = false;
            _participants = new List<IPartecipant>();

            _roomType = roomType;
            _z = z;
            _y = y;
            _x = x;

            _isActive = 1;

        }
        public RoomType GetRoomType()
        {
            return _roomType;
        }
        public int GetZ()
        {
            return _z;
        }
        public int GetY()
        {
            return _y;
        }
        public int GetX()
        {
            return _x;
        }

        List<IPartecipant> IRoom.GetPartecipants()
        {
            return _participants;
        }

        public void AddPartecipants(List<IPartecipant> participants)
        {

        }

        public void AddPartecipant(IPartecipant participant)
        {
            _participants.Add(participant);
            participant.SetRoom(this);
        }

        public void RemovePartecipant(IPartecipant participant)
        {
            _participants.Remove(participant);
        }

        public void SetWasVisitedByPlayer()
        {
            wasVisitedByPlayer = true;
        }

        public bool GetWasVisitedByPlayer()
        {
            return wasVisitedByPlayer;
        }

        public void SetRoomType(RoomType roomtype)
        {
            this._roomType = roomtype;
        }

        public void ChangeActivity(int isActive)
        {
            _isActive = isActive;
        }

        public int GetActivity()
        {
            return _isActive;
        }
    }
}
