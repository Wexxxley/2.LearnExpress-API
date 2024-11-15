using AutoMapper;
using LearnExpress.Application.DTOs;
using LearnExpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Mapping
{
    public class ToDTOMappingProfile : Profile
    {
        public ToDTOMappingProfile()
        {
            //curso
            CreateMap<Curso, CursoRequestDTO>().ReverseMap();
            CreateMap<Curso, CursoResponseDTO>().ReverseMap();
            //category
            CreateMap<Categorium, CategoryRequestDTO>().ReverseMap();
            CreateMap<Categorium, CategoryResponseDTO>().ReverseMap();
            //Usuarios
            CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseDTO>().ReverseMap();
            //Progresso
            CreateMap<PorcentConcluCurso, ProgressoRequestDTO>().ReverseMap();
            CreateMap<PorcentConcluCurso, ProgressoResponseDTO>().ReverseMap();
            //Pedido
            CreateMap<Pedido, PedidoRequestDTO>().ReverseMap();
            CreateMap<Pedido, PedidoResponseDTO>().ReverseMap();
            //Aula
            CreateMap<Aula, AulaRequestDTO>().ReverseMap();
            CreateMap<Aula, AulaResponseDTO>().ReverseMap();
        }
    }
}
