using Bliss.API.ExceptionHandling;
using Bliss.Application.Questions;
using Bliss.Model.Questions;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.API.Controllers
{
    [AllowAnonymous]
    [Route("questions")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(
            IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        public IActionResult Add(QuestionsViewModel model) => _questionsService.AddAsync(model).ApiResult();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => _questionsService.GetAsync(id).ApiResult();

        [HttpGet("grid")]
        public IActionResult Grid([FromQuery] GridParameters parameters) =>
            _questionsService.GridAsync(parameters).ApiResult();

        [HttpGet]
        public IActionResult List() => _questionsService.ListAsync().ApiResult();

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] QuestionsViewModel model) =>
            _questionsService.UpdateAsync(model).ApiResult();
    }
}
