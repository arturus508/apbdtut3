 using Microsoft.AspNetCore.Mvc;
using VeterinaryClinicApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace VeterinaryClinicApi.Controllers
{
        // Controller for \visits to the vet clinic
    [ApiController]
    [Route("api/animals/{animalId}/records")]
    public class VisitManager : ControllerBase
    {
        private static List<Visit> _visitRecords = new List<Visit>();

         // get  all visits for   sepcific animal
        [HttpGet]
        public ActionResult<List<Visit>> GetAllVisits(int animalId)
        {
            var relatedVisits = _visitRecords.Where(v => v.AnimalId == animalId).ToList();
            if (!relatedVisits.Any()) return NotFound("No visits recorded for this animal.");
            return relatedVisits;
        }

            // Log new visit for a   animal
        [HttpPost]
            public ActionResult<Visit> RecordVisit(int animalId, Visit visit)
        {
            visit.AnimalId = animalId;
            visit.Id = _visitRecords.Any() ? _visitRecords.Max(v => v.Id) + 1 : 1;
            _visitRecords.Add(visit);
            return CreatedAtAction("GetAllVisits", new { animalId = visit.AnimalId }, visit);
        }
    }
}
