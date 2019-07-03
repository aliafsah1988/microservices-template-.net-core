using System.Threading.Tasks;
using ServiceA.Business.Exceptions;

namespace ServiceA.Business.Validation
{
    public static class AValidation
    {
        public static async Task Validate(this Domain.SomeModel someModel)
        {
            if (someModel.AppId == null)
            {
                throw new CustomeException();
            }

            await Task.CompletedTask;
        }
    }
}
