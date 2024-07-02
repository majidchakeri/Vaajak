using Vaajak.Domain.Entities;

{
    public interface IVocabsRepository
    {
        Task<IEnumerable<Vocab>> GetAllAsync();
        Task<Vocab?> GetByIdAsync(Guid id);
        Task<Vocab> CreateVocab(CreateVocabDto createVocabDto);
    }
}
