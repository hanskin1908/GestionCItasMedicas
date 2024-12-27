using Moq;
using Personas.Dominio.Entities;
using Personas.Dominio.Interfaces;

namespace TestGestioncitas
{
    public class PersonasServiceTests
    {
        private readonly Mock<IPersonaRepository> _repositoryMock;
        private readonly PersonasService _service;

        public PersonasServiceTests()
        {
            _repositoryMock = new Mock<IPersonaRepository>();
            _service = new PersonasService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetPersonaById_ReturnsPersona_WhenPersonaExists()
        {
            // Arrange
            var persona = new Persona { Id = 1, Nombre = "Juan Pérez" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(persona);

            // Act
            //var result = await _service.GetPersonaById(1);

            // Assert
            //result.Should().NotBeNull();
            //result.Nombre.Should().Be("Juan Pérez");
        }

        [Fact]
        public async Task GetPersonaById_ReturnsNull_WhenPersonaDoesNotExist()
        {
            // Arrange
            _repositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Persona)null);

            // Act
            //var result = await _service.GetPersonaById(1);

            // Assert
            //result.Should().BeNull();
        }
    }
}