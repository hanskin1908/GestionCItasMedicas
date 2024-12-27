using Cita.Infrastructure.MessageBus;
using Citas.APi.Controllers;
using Citas.Application.DTOs;
using Citas.Application.Queries;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGestioncitas
{
    public class CitasControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<RabbitMQPublisher> _rabbitMqMock;
        private readonly CitasController _controller;

        public CitasControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _rabbitMqMock = new Mock<RabbitMQPublisher>("localhost", "citas_exchange", "guest", "guest");
            _controller = new CitasController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Finalize_SendsMessageToRabbitMQ_WhenCitaIsFinalized()
        {
            // Arrange
            var citaDto = new CitaDto { Id = 1, PacienteId = 123, MedicoId = 456, Estado = "Pendiente" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetCitaByIdQuery>(), default)).ReturnsAsync(citaDto);

            // Act
            var result = await _controller.Finalize(1);

            // Assert
            _rabbitMqMock.Verify(mq => mq.PublicarMensaje( "cita.finalizada"), Times.Once);
        }
    }
}
