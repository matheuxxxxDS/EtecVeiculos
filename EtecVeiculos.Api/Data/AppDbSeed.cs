using EtecVeiculos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EtecVeiculos.Api.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder modelBuilder)
    {
        #region TipoVeiculo
        List<TipoVeiculo> tipoVeiculos = [
            new(){
                Id = 1,
                Nome = "Carro"
            },
            new(){
                Id = 2,
                Nome = "Moto"
            },
            new(){
                Id = 3,
                Nome = "Caminhão"
            }
        ];
        modelBuilder.Entity<TipoVeiculo>().HasData(tipoVeiculos);
    #endregion

        #region Marcas
        
                List<Marca> marcas = [
            new(){
                Id = 1,
                Nome = "Chevrolet"
            },
            new(){
                Id = 2,
                Nome = "Toyota"
            },
            new(){
                Id = 3,
                Nome = "Volkswagen"
            }
        ];
        modelBuilder.Entity<Marca>().HasData(marcas);
     #endregion



        #region Modelo

        List<Modelo> modelos = new() {
            new() {
                Id= 1,
                Nome= "Opala",
                MarcaId = 1
            }
        };


        _ = new
        List<Modelo>() {
            new() {
                Id= 2,
                Nome= "Corolla",
                MarcaId = 1
            }
        };


        _ = new
        List<Modelo>() {
            new() {
                Id= 3,
                Nome= "Gol",
                MarcaId = 1
            }
        };


        modelBuilder.Entity<Modelo>().HasData(modelos);
    #endregion
        
    }
}
