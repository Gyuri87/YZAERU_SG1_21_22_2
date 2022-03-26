using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YZAERU_SG1_21_22_2.Logic.Interfaces;
using YZAERU_SG1_21_22_2.Logic.Services;
using YZAERU_SG1_21_22_2.Models.Entities;
using YZAERU_SG1_21_22_2.Models.Models;

namespace YZAERU_SG1_21_22_2.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorController : Controller
    {

        readonly IActorLogic actorLogic;

        public ActorController(IActorLogic actorLogic)
        {
            this.actorLogic = actorLogic;
        }

        // /api/Actor/ListActors
        [HttpGet]
        [ActionName("ListActors")]
        public IList<Actor> GetActors()
        {
            return actorLogic.GetAllActors();
        }

        // /api/Actor/ListActress
        [HttpGet]
        [ActionName("ListActress")]
        public IList<Actor> GetActress()
        {
            return actorLogic.GetAllActress();
        }

        // /api/Actor/GetActor/5
        [HttpGet("{id}")]
        public Actor GetActor(int id)
        {
            return actorLogic.GetOneActor(id);
        }

        // /api/Actor/Create
        [HttpPost]
        [ActionName("Create")]
        public Actor Post(Actor actor)
        {
            return actorLogic.InsertActor(actor);
        }

        // /api/Actor/Delete/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);
            try
            {
                actorLogic.DeletActor(id);
            }
            catch(Exception){
                result.IsSuccess = false;
            }

            return result;
        }

        // /api/Actor/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Actor actor)
        {
            var result = new ApiResult(true);
            try
            {
                actorLogic.UpdatActor(actor);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }

            return result;
        }
    }
}
