//using AutoMapper;
//using ChallengeSND.business.Services;
//using ChallengeSND.Business.DTOS;
//using ChallengeSND.Business.Servicies.Interfaces;
//using ChallengeSND.Data.Models;
//using ChallengeSND.Data.Repositories.Interfaces;
//using Infraestructure.Core.UnitOfWork.Interface;
//using Moq;

//namespace ChallengeSND.Test
//{


//    public class MedicoServiceTests
//    {
//        private readonly Mock<IRepository<Medico>> _medicoRepositoryMock;
//        private readonly Mock<IMapper> _mapperMock;
//        private readonly IMedicoService _medicoService;

//        public MedicoServiceTests()
//        {
//            _medicoRepositoryMock = new Mock<IRepository<Medico>>();
//            _mapperMock = new Mock<IMapper>();
//            _medicoService = new MedicoService(_medicoRepositoryMock.Object, _mapperMock.Object);
//        }

//        [Fact]
//        public async Task GetAllMedicos_ShouldReturnAllMedicos()
//        {
//            // Arrange
//            var medicos = new List<Medico> { new Medico(), new Medico() };
//            _medicoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(medicos);
//            _mapperMock.Setup(m => m.Map<IEnumerable<MedicoDto>>(It.IsAny<IEnumerable<Medico>>())).Returns(new List<MedicoDto>());

//            // Act
//            var result = await _medicoService.GetAllMedicos();

//            // Assert
//            Assert.NotNull(result);
//            _medicoRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
//        }

//        [Fact]
//        public async Task GetMedicoById_ShouldReturnMedico()
//        {
//            // Arrange
//            var medico = new Medico { Id = 1 };
//            _medicoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(medico);
//            _mapperMock.Setup(m => m.Map<MedicoDto>(It.IsAny<Medico>())).Returns(new MedicoDto());

//            // Act
//            var result = await _medicoService.GetMedicoById(1);

//            // Assert
//            Assert.NotNull(result);
//            _medicoRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
//        }

//        [Fact]
//        public async Task CreateMedico_ShouldAddMedico()
//        {
//            // Arrange
//            var medicoDto = new MedicoDto();
//            var medico = new Medico();
//            _mapperMock.Setup(m => m.Map<Medico>(It.IsAny<MedicoDto>())).Returns(medico);
//            _medicoRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Medico>())).Returns(Task.CompletedTask);

//            // Act
//            await _medicoService.CreateMedico(medicoDto);

//            // Assert
//            _medicoRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Medico>()), Times.Once);
//        }

//        [Fact]
//        public async Task UpdateMedico_ShouldUpdateMedico()
//        {
//            // Arrange
//            var medicoDto = new MedicoDto();
//            var medico = new Medico();
//            _mapperMock.Setup(m => m.Map<Medico>(It.IsAny<MedicoDto>())).Returns(medico);
//            _medicoRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Medico>())).Returns(Task.CompletedTask);

//            // Act
//            await _medicoService.UpdateMedico(medicoDto);

//            // Assert
//            _medicoRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Medico>()), Times.Once);
//        }

//        [Fact]
//        public async Task DeleteMedico_ShouldDeleteMedico()
//        {
//            // Arrange
//            var medico = new Medico { Id = 1 };
//            _medicoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(medico);
//            _medicoRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

//            // Act
//            await _medicoService.DeleteMedico(1);

//            // Assert
//            _medicoRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
//        }
//    }
//}
