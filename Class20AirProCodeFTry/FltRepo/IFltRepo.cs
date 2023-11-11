using Class20AirProCodeFTry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class20AirProCodeFTry.FltRepo
{
    public interface IFltRepo
    {
        Task<ActionResult<IEnumerable<Flight>>> GetFlights();
        Task<ActionResult<Flight>> PostFlights(Flight flight);
        Task<ActionResult<Flight>> PutFlights(Flight flight);
        Task<ActionResult<Flight>> DeleteFlights(int id);
    }
}
