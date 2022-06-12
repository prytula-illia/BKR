using DTOs;

namespace BLL.Interfaces
{
    public interface IDotNetCompilerService
    {
        public CodeDto Compile(CodeDto code);
    }
}
