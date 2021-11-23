using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minly.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Star> Stars { get; }
        IGenericRepository<Service> Services { get; }

        IGenericRepository<Event> Events { get; }
        IGenericRepository<EventType> EventTypes { get; }
        IGenericRepository<EventMembership> EventMemberships { get; }
        IGenericRepository<EventVideo> EventVideos { get; }
        IGenericRepository<Sponsor> Sponsors { get; }
        IGenericRepository<StarRate> StarRates { get; }
        IGenericRepository<EventRate> EventRates { get; }
        IGenericRepository<RequestEvent> RequestEvents { get; }
        IGenericRepository<RequestStar> RequestStars { get; }
        IGenericRepository<StarResponse> StarResponses { get; }


        Task Save();
        double GetRatesOfEvents();
        double GetRatesOfStars();
    }
}
