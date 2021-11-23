using Minly.Core.IRepository;
using Minly.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minly.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Service> _services;
        private IGenericRepository<Star> _stars;
        private IGenericRepository<Event> _events;
        private IGenericRepository<EventType> _eventtypes;
        private IGenericRepository<EventMembership> _eventmemberships;
        private IGenericRepository<EventVideo> _eventvideos;
        private IGenericRepository<Sponsor> _sponsors;
        private IGenericRepository<EventRate> _eventrates;
        private IGenericRepository<StarRate> _starrates;
        private IGenericRepository<RequestEvent> _requestevents;
        private IGenericRepository<RequestStar> _requeststars;
        private IGenericRepository<StarResponse> _starresponse;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Star> Stars => _stars ??= new GenericRepository<Star>(_context);
        public IGenericRepository<Service> Services => _services ??= new GenericRepository<Service>(_context);
        public IGenericRepository<Event> Events => _events ??= new GenericRepository<Event>(_context);
        public IGenericRepository<EventType> EventTypes => _eventtypes ??= new GenericRepository<EventType>(_context);
        public IGenericRepository<EventMembership> EventMemberships => _eventmemberships ??= new GenericRepository<EventMembership>(_context);
        public IGenericRepository<EventVideo> EventVideos => _eventvideos ??= new GenericRepository<EventVideo>(_context);
        public IGenericRepository<Sponsor> Sponsors => _sponsors ??= new GenericRepository<Sponsor>(_context);
        public IGenericRepository<EventRate> EventRates => _eventrates ??= new GenericRepository<EventRate>(_context);
        public IGenericRepository<StarRate> StarRates => _starrates ??= new GenericRepository<StarRate>(_context);
        public IGenericRepository<RequestEvent> RequestEvents => _requestevents ??= new GenericRepository<RequestEvent>(_context);
        public IGenericRepository<RequestStar> RequestStars => _requeststars ??= new GenericRepository<RequestStar>(_context);
        public IGenericRepository<StarResponse> StarResponses => _starresponse ??= new GenericRepository<StarResponse>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public double GetRatesOfEvents()
        {
            double sum = _context.EventRates.Select(t => t.Rate).Sum();
            return sum;
        }
        public double GetRatesOfStars()
        {
            double sum = _context.StarRates.Select(t => t.Rate).Sum();
            return sum;
        }
    }
}
