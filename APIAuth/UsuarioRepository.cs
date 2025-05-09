namespace APIAuth
{
    public static class UsuarioRepository
    {
        public static List<Usuario> Usuarios { get; } = new List<Usuario>
    {
        new Usuario { ID = 1, Nome = "Alexandre Sampaio", Email = "alexandre@teste.com", Senha = "123456" },
        new Usuario { ID = 2, Nome = "Camila Oliveira", Email = "camila@teste.com", Senha = "654321" },
        new Usuario { ID = 3, Nome = "João Martins", Email = "joao@teste.com", Senha = "senha123" },
        new Usuario { ID = 4, Nome = "Patrícia Souza", Email = "patricia@teste.com", Senha = "teste321" },
        new Usuario { ID = 5, Nome = "Eduardo Lima", Email = "eduardo@teste.com", Senha = "meusegredo" }
    };
    }
}
