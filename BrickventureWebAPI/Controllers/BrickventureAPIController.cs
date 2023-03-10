﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Brickventure_Library.Environment;
using Brickventure_Library_0._1;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.Environment;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using BrickventureWebAPI.DTOs;

namespace BrickventureWebAPI.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/brickventureAPI")]
    [ApiController]
    public class BrickventureAPIController : Controller
    {
        private readonly IWorld _world;
        private readonly IOutputMessageWriter _messageWriter;
        private readonly IController _controller;
        private readonly IOutputMessageWriter _outputMessageWriter;
        private readonly IPlayerStateTimer _playerStateTimer;
        public BrickventureAPIController(IWorld world, IOutputMessageWriter messageWriter, IController controller, IOutputMessageWriter outputMessageWriter, IPlayerStateTimer playerStateTimer)
        {
            _world = world;
            _messageWriter = messageWriter; 
            _controller = controller;
            _outputMessageWriter = outputMessageWriter;
            _playerStateTimer = playerStateTimer;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetWorldGameField")]
        public WorldDTO GetWorldGameField()
        {
            _playerStateTimer.Start();
            return new WorldDTO(_world, _outputMessageWriter);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("CreatePlayer")]
        public PartecipantDTO CreatePlayer()
        {
            var p = new Player(_world, _messageWriter);
            return new PartecipantDTO(p);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("MoveUp")]
        public WorldDTO MoveUp()
        {
            _outputMessageWriter.Clear();
            _controller.PerformCommand("w");
            return new WorldDTO(_world, _outputMessageWriter);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("MoveLeft")]
        public WorldDTO MoveLeft()
        {
            _outputMessageWriter.Clear();
            _controller.PerformCommand("a");
            return new WorldDTO(_world, _outputMessageWriter);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("MoveDown")]
        public WorldDTO MoveDown()
        {

            _outputMessageWriter.Clear();
            _controller.PerformCommand("s");
            return new WorldDTO(_world, _outputMessageWriter);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("MoveRight")]
        public WorldDTO MoveRight()
        {
            _outputMessageWriter.Clear();
            
            _controller.PerformCommand("d");
            return new WorldDTO(_world, _outputMessageWriter);
        }




    }
}