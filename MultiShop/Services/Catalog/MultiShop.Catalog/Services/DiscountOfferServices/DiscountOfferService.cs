using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.DiscountOfferServices
{
    public class DiscountOfferService : IDiscountOfferService
    {
        private readonly IMongoCollection<DiscountOffer> _discountOfferCollection;
        private readonly IMapper _mapper;

        public DiscountOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountOfferCollection = database.GetCollection<DiscountOffer>(_databaseSettings.DiscountOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
        {
            var value = _mapper.Map<DiscountOffer>(createDiscountOfferDto);
            await _discountOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountOfferAsync(string id)
        {
            await _discountOfferCollection.DeleteOneAsync(x => x.DiscountOfferId == id);
        }

        public async Task<GetByIdDiscountOfferDto> GetByIdDiscountOfferAsync(string id)
        {
            var values = await _discountOfferCollection.Find<DiscountOffer>(x => x.DiscountOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDiscountOfferDto>(values);
        }

        public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync()
        {
            var values = await _discountOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountOfferDto>>(values);
        }

        public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            var values = _mapper.Map<DiscountOffer>(updateDiscountOfferDto);
            await _discountOfferCollection.FindOneAndReplaceAsync(x => x.DiscountOfferId == updateDiscountOfferDto.DiscountOfferId, values);
        }
    }
}
