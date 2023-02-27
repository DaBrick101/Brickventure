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
        public BrickventureAPIController(IWorld world, IOutputMessageWriter messageWriter)
        {
            _world = world;
            _messageWriter = messageWriter; 
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetWorldGameField")]
        public IList<RoomDTO>GetWorldGameField()
        {
            try
            {
                WorldDTO world = new WorldDTO(_world);

                //RoomDTO room = new RoomDTO(world.GetCurrentRoom());
                List<RoomDTO> roomList = new List<RoomDTO>();

                var iroomList = world.GetGameField();
                foreach (var iroom in iroomList)
                {
                    RoomDTO room = new RoomDTO(iroom);
                    roomList.Add(room);
                }

                return roomList;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("CreatePlayer")]
        public PartecipantDTO CreatePlayer()
        {
            var p = new Player(_world, _messageWriter);
            return new PartecipantDTO(p);
        }

    }
}