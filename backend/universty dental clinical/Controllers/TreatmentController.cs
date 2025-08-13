using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universty_dental_clinical.DTO.Treatment;
using universty_dental_clinical.Models;

namespace universty_dental_clinical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDBContext _context;

        public TreatmentController(AppDBContext db, IMapper mapper)
        {
            _context = db;
            _mapper = mapper;
        }
        [HttpGet]
       
        public IActionResult Get()
        {
            var allTreatment = _context.Treatments.ToList();

            var treatmentDtos = _mapper.Map<List<GetTreatment>>(allTreatment);

            return Ok(treatmentDtos);
        }

        [HttpGet("Gettreatment/{id}")]
        public IActionResult Get(int id)
        {
            var treatment = _context.Treatments.FirstOrDefault(D => D.Id == id);
            if (treatment != null)
            {
                var getTreatmetn = new GetTreatment
                {
                    Id = treatment.Id,
                    Name = treatment.Name,
                    Description = treatment.Description,
                    Duration= treatment.Duration,
                    Cost= treatment.Cost,
                };

                return Ok(getTreatmetn);
            }
            else
            {
                return NotFound($"treatment with ID {id} not found.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] CreateTreatment treatment)
        {
            var newAD = _mapper.Map<Treatment>(treatment);

            _context.Treatments.Add(newAD);
            _context.SaveChanges();
            return Ok($"Added Successfully {newAD.Name}");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedAD = _context.Treatments.FirstOrDefault(c => c.Id == id);
            if (deletedAD != null)
            {
                _context.Treatments.Remove(deletedAD);
                _context.SaveChanges();
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound($"{id} Not Found in treatment ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatedTreatment treatment)
        {
            var Editedtreatment = _context.Treatments.FirstOrDefault(p => p.Id == id);

            if (Editedtreatment == null)
            {
                return NotFound("Treatment not found ");
            }

            Editedtreatment.Cost = treatment.Cost;
            Editedtreatment.Duration = treatment.Duration;
            _context.SaveChanges();
            return Ok();

        }
    }
}
