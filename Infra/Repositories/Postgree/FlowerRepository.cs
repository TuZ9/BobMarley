using BobMarley.Domain.Entities;
using BobMarley.Domain.Interfaces.Repositories;
using BobMarley.Infra.Context;
using Microsoft.Extensions.Logging;

namespace BobMarley.Infra.Repositories.Postgree
{
    public class FlowerRepository : AuroraRepository<Flower>, IFlowerRepository
    {
        private readonly ILogger<FlowerRepository> _logger;
        public FlowerRepository(AuroraDbContext context, ILogger<FlowerRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task Delete(Flower flower)
        {
            try
            {
                var query = @"DELETE FROM public.Flower AS tgt
                              USING SOURCE_TABLE AS src
                              WHERE tgt.id_flower=src.id_flower;";
                await DeleteAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error ao Deletar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Flower>> Get()
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                return await GetListAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Buscar Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Insert(IEnumerable<Flower> flower)
        {
            try
            {
                var query = @"INSERT INTO public.Flower
                              (name, type, description, qr, url, image, labtest, thc, cbd, createdat, updatedat, id_brand, id_strain, id_flower)
                              VALUES('', '', '', '', '', '', false, false, false, '', '', ?, ?, ?);";

                await InsertAsync(query, flower);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Inserir Flower: {0}", ex.Message);
                throw;
            }
        }

        public async Task Update(IEnumerable<Flower> flower)
        {
            try
            {
                var query = @"UPDATE public.Flower
                              SET 
                              name='', type='', description='', qr='', url='', image='', labtest=false, 
                              thc=false, cbd=false, createdat='', updatedat='', id_brand=?, id_strain=?
                              WHERE id_flower=?;";

                await UpdateAsync(query, flower);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao Update Flower: {0}", ex.Message);
                throw;
            }
        }
    }
}
