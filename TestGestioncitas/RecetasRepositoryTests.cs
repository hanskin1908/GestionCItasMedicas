using Microsoft.EntityFrameworkCore;
using Moq;
using Recetas.Domain.Entities;
using Recetas.Domain.Interfaces;
using Recetas.Infrastructure.Data;
using Recetas.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGestioncitas
{
    public class RecetasRepositoryTests
    {
        //public async Task GetAllAsync_ShouldReturnAllRecetas()
        //{
        //    // Datos simulados
        //    var recetasData = new List<Receta>
        //{
        //    new Receta { Id = 1, Codigo = "Receta 1", Descripcion = "Descripción 1" },
        //    new Receta { Id = 2, Codigo = "Receta 2", Descripcion = "Descripción 2" }
        //}.AsQueryable();

        //    // Simular DbSet con datos
        //    var mockSet = new Mock<DbSet<Receta>>();
        //    mockSet.As<IQueryable<Receta>>().Setup(m => m.Provider).Returns(recetasData.Provider);
        //    mockSet.As<IQueryable<Receta>>().Setup(m => m.Expression).Returns(recetasData.Expression);
        //    mockSet.As<IQueryable<Receta>>().Setup(m => m.ElementType).Returns(recetasData.ElementType);
        //    mockSet.As<IQueryable<Receta>>().Setup(m => m.GetEnumerator()).Returns(recetasData.GetEnumerator());

        //    // Simular DbContext
        //    var mockContext = new Mock<RecetasDbContext>();
        //    mockContext.Setup(c => c.Recetas).Returns(mockSet.Object);

        //    // Crear el repositorio con el contexto simulado
        //    var repository = new RecetaRepository(mockContext.Object);

        //    // Ejecutar el método a probar
        //    var result = await repository.GetAllAsync();

        //    // Verificar resultados
        //    Assert.Equal(2, result.Count);
        //    Assert.Equal("Receta 1", result[0].Nombre);
        //    Assert.Equal("Receta 2", result[1].Nombre);
        //}
    }
}
