using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VueJSAspNetCoreWeb.Models;

namespace VueJSAspNetCoreWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PipelineController : ControllerBase
    {
        private readonly PipelineService _pipelineService;

        public PipelineController(PipelineService pipelineService)
        {
            _pipelineService = pipelineService;
        }

        [HttpGet]
        public ActionResult<List<Pipeline>> Get() =>
            _pipelineService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPipeline")]
        public ActionResult<Pipeline> Get(string id)
        {
            var pipeline = _pipelineService.Get(id);

            if (pipeline == null)
            {
                return NotFound();
            }

            return pipeline;
        }

        [HttpPost]
        public async Task<ActionResult<Pipeline>> CreateAsync(Pipeline pipeline)
        {
            await _pipelineService.Create(pipeline);

            return CreatedAtRoute("GetPipeline", new { id = pipeline.PipelineId.ToString() }, pipeline);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var pipeline = _pipelineService.Get(id);

            if (pipeline == null)
            {
                return NotFound();
            }

            await _pipelineService.Remove(pipeline.PipelineId);

            return NoContent();
        }
    }
}
