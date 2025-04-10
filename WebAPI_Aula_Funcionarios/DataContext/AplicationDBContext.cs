using Microsoft.EntityFrameworkCore;
using WebAPI_Aula_Funcionarios.Models;

namespace WebAPI_Aula_Funcionarios.DataContext
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options) 
        { 
        }

        public DbSet<FuncionarioModel> Funcionarios {  get; set; } 
    }
}
