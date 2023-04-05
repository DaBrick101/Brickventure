using Microsoft.AspNetCore.Components;
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
        
        private bool isRestarting;
        private WorldDTO lastWorldDto;
        
        public BrickventureAPIController(IWorld world, IOutputMessageWriter messageWriter, IController controller, IOutputMessageWriter outputMessageWriter, IPlayerStateTimer playerStateTimer)
        {
            _world = world;
            _messageWriter = messageWriter; 
            _controller = controller;
            _outputMessageWriter = outputMessageWriter;
            _playerStateTimer = playerStateTimer;

            _playerStateTimer.Start();
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetWorldGameField")]
        public WorldDTO GetWorldGameField()
        {
            if (isRestarting) return lastWorldDto;
            lastWorldDto = new WorldDTO(_world, _outputMessageWriter);
            return lastWorldDto;
        }


        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("CreatePlayer")]
        public PartecipantDTO CreatePlayer()
        {
            var p = new Player(_world, _messageWriter);
            return new PartecipantDTO(p);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Restart")]
        public WorldDTO Restart()
        {
            isRestarting = true;
            _playerStateTimer.Reset();
            _world.GetPlayer().SetHealth(3);
            _world.Restart();
            isRestarting = false;
            return new WorldDTO(_world, _outputMessageWriter);
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
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Attack")]
        public WorldDTO Attack()
        {
            _outputMessageWriter.Clear();

            _controller.PerformCommand("q");
            return new WorldDTO(_world, _outputMessageWriter);
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Defend")]
        public WorldDTO Defend()
        {
            _outputMessageWriter.Clear();

            _controller.PerformCommand("e");
            return new WorldDTO(_world, _outputMessageWriter);
        }
    }
}