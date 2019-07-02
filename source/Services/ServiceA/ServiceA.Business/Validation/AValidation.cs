using System.Threading.Tasks;
using ServiceA.Business.Exceptions;

namespace ServiceA.Business.Validation
{
    public static class AValidation
    {
        public static async Task Validate(this Domain.A a)
        {
            if (a.AppId == null)
            {
                throw new CustomeException();
            }

            await Task.CompletedTask;
        }
    }
}
