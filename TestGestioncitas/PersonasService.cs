using Personas.Dominio.Interfaces;

namespace TestGestioncitas
{
    internal class PersonasService
    {
        private IPersonaRepository @object;

        public PersonasService(IPersonaRepository @object)
        {
            this.@object = @object;
        }

        internal async Task GetPersonaById(int v)
        {
            throw new NotImplementedException();
        }
    }
}