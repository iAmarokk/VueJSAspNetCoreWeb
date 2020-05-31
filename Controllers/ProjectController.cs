using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueJSAspNetCoreWeb.Models;

namespace VueJSAspNetCoreWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService userService)
        {
            _projectService = userService;
        }

        [HttpGet]
        public ActionResult<List<Project>> Get() =>
            _projectService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<Project> Get(string id)
        {
            var project = _projectService.Get(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateAsync(Project project)
        {
            await _projectService.Create(project);

            return CreatedAtRoute("GetUser", new { id = project.Id.ToString() }, project);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var project = _projectService.Get(id);

            if (project == null)
            {
                return NotFound();
            }

            await _projectService.Remove(project.Id);

            return NoContent();
        }
    }
}
